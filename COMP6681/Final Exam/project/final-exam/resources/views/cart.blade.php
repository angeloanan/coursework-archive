<x-layout title="Cart">
  <div class="mx-auto w-full max-w-screen-lg my-8">
    <h1 class="underline text-lg font-medium">Cart</h1>

    <ol class="space-y-4 my-4">
      @foreach ($orders as $order)
        <li class="grid grid-cols-4 items-center">
          <img src="" class="w-32 h-32 object-cover bg-slate-700 rounded-full">

          <div>
            <span class="text-lg font-medium">{{ $order->item->item_name }}</span>
          </div>

          <div>
            <span class="">Rp. {{ number_format($order->price, 0, ',', '.') }}</span>
          </div>

          <div>
            <a href="{{ '/item/' . $order->item_id . '/delete' }}" class="text-blue-900 underline">
              {{ __('cartDeleteProduct') }}
            </a>
          </div>
        </li>
      @endforeach
    </ol>

    <div class="flex justify-end items-baseline gap-4">
      <span class="font-medium">{{ __('cartTotal') }}: {{ number_format($total, 0, ',', '.') }}</span>

      <a href="/checkout" class="bg-green-300 px-4 py-2 rounded-lg">Checkout</a>
    </div>
  </div>

</x-layout>
