<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Item;
use App\Models\Order;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Log;

class ItemController extends Controller
{
    public function __construct()
    {
        $this->middleware('authenticated');
    }

    public function allItemPage(Request $request)
    {
        return view('item.index', [
            'items' => Item::paginate(10)->withQueryString()
        ]);
    }

    public function itemPage(Request $request)
    {
        return view('item.entry', ['item' => Item::findOrFail($request->id)]);
    }

    public function cartPage()
    {
        $orders = Order::where('account_id', Auth::user()->account_id)->get();
        $total = 0;

        foreach ($orders as $order) {
            $total += $order->price;
        }

        return view('cart', ['orders' => $orders, "total" => $total]);
    }

    public function checkoutPage()
    {
        Order::where('account_id', Auth::user()->account_id)->delete();

        return view('checkout');
    }

    // ----- Functionality below

    public function addItemToCart(Request $request)
    {
        $item = Item::findOrFail($request->id);
        Log::info($item->id);
        $order = new Order();

        $order->item_id = $item->item_id;
        $order->account_id = Auth::user()->account_id;
        $order->price = $item->price;
        $order->save();

        return redirect('/cart');
    }

    public function removeItemFromCart(Request $request)
    {
        $order = Order::where('item_id', $request->id)->where('account_id', Auth::user()->account_id)->first();
        $order->delete();

        return redirect('/cart');
    }
}
