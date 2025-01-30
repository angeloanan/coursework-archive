<?php

namespace App\Http\Controllers;

use App\Models\Gender;
use App\Models\Role;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Validator;
use Illuminate\Validation\Rule;
use Illuminate\Validation\Rules\File;
use Illuminate\Validation\Rules\Password;
use Illuminate\Support\Facades\Storage;

class UserController extends Controller
{
    // ----- Validation rules

    function registerUserDataValidationRule()
    {
        return [
            'firstName' => ['required', 'max:25', 'alpha_num:ascii'],
            'lastName' => ['required', 'max:25', 'alpha_num:ascii'],
            'email' => ['required', 'email:rfc'],
            'role' => ['required', Rule::in(['user', 'admin'])],
            'gender' => ['required'],
            'pfp' => ['required', File::image()],
            'password' => ['required', Password::min(8)->numbers()],
            'confirmPassword' => ['required', 'same:password'],
        ];
    }

    function UpdateUserDataValidationRule()
    {
        return [
            'firstName' => ['required', 'max:25', 'alpha_num:ascii'],
            'lastName' => ['required', 'max:25', 'alpha_num:ascii'],
            'email' => ['required', 'email:rfc'],
            'role' => ['required', Rule::in(['user', 'admin'])],
            'gender' => ['required'],
            'pfp' => [File::image()],
            'password' => ['required', Password::min(8)->numbers()],
            'confirmPassword' => ['required', 'same:password'],
        ];
    }


    public function registerPage()
    {
        return view('register');
    }

    public function loginPage()
    {
        return view('login');
    }

    public function logoutPage()
    {
        auth()->logout();

        return view('logout');
    }

    public function profilePage()
    {
        return view('profile');
    }

    // ----- Functionality below

    // TODO: Handle form Validation
    public function registerUser(Request $request)
    {

        $registerData = Validator::make($request->all(), $this->registerUserDataValidationRule())->validateWithBag('registerData');

        $pfpName = time() . '.' . $request->file('pfp')->extension();
        $request->file('pfp')->storeAs('public/pfp', $pfpName);
        $role = Role::where('role_name', $registerData['role'])->first();
        $gender = Gender::where('gender_desc', $registerData['gender'])->first();

        $user = new User([
            'first_name' => $registerData['firstName'],
            'last_name' => $registerData['lastName'],
            'email' => $registerData['email'],
            'password' => $registerData['password'],
        ]);

        $user->display_picture_link = '/pfp/' . $pfpName;
        $user->role_id = $role->role_id;
        $user->gender_id = $gender->gender_id;
        $user->save();

        auth()->login($user);
        return redirect()->to('item');
    }

    public function loginUser(Request $request)
    {
        $loginValidation = [
            'email' => ['required', 'email:rfc'],
            'password' => ['required', Password::min(8)],
        ];

        $loginData = Validator::make($request->all(), $loginValidation)->validateWithBag('loginData');

        if (Auth::attempt($loginData)) {
            $request->session()->regenerate();
            return redirect()->intended('item');
        }

        return back()->withErrors([
            'loginData' => 'The provided credentials do not match our records.',
        ])->onlyInput('email');
    }

    public function updateUser(Request $request)
    {
        $updateData = Validator::make($request->all(), $this->UpdateUserDataValidationRule())->validateWithBag('updateData');

        if ($request->file('pfp') != null) {
            $pfpName = time() . '.' . $request->file('pfp')->extension();
            $request->file('pfp')->storeAs('public/pfp', $pfpName);
            $pfpPath = '/pfp/' . $pfpName;
        } else {
            $pfpPath = auth()->user()->display_picture_link;
        }

        $user = User::where('account_id', auth()->user()->account_id)->first();
        $user->first_name = $updateData['firstName'];
        $user->last_name = $updateData['lastName'];
        $user->email = $updateData['email'];
        $user->password = $updateData['password'];
        $user->display_picture_link = $pfpPath;

        $user->save();

        return redirect()->to('profile');
    }
}
