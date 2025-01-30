<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use App\Models\Role;

class AdminController extends Controller
{
    public function __construct()
    {
        $this->middleware('authenticated');
        $this->middleware('admin');
    }

    public function adminPage()
    {
        $users = User::all();

        return view('admin.index', ['users' => $users]);
    }

    public function changeRolePage(Request $request)
    {
        $user = User::find($request->query('id'));

        return view('admin.changerole', ['user' => $user]);
    }

    public function deleteUser(Request $request)
    {
        User::find($request->query('id'))->delete();

        return redirect()->route('admin');
    }

    // ----- Functionality

    public function changeRole(Request $request)
    {
        $user = User::find($request->query('id'));
        $role = Role::where('role_name', $request->input('role'))->first();

        $user->role_id = $role->role_id;
        $user->save();

        return redirect()->route('admin');
    }
}
