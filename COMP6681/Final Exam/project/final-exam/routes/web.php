<?php

use App\Http\Controllers\AdminController;
use App\Http\Controllers\ItemController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\UserController;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

// Users
Route::get('/login', [UserController::class, 'loginPage'])->name('login');
Route::post('/login', [UserController::class, 'loginUser']);
Route::get('/register', [UserController::class, 'registerPage'])->name('register');
Route::post('/register', [UserController::class, 'registerUser']);
Route::get('/logout', [UserController::class, 'logoutPage'])->name('logout');
Route::get('/profile', [UserController::class, 'profilePage'])->middleware('authenticated')->name('profile');
Route::post('/profile', [UserController::class, 'updateUser'])->middleware('authenticated');

// Item
Route::get('/item/', [ItemController::class, 'allItemPage'])->name('allItem');
Route::get('/item/{id}', [ItemController::class, 'itemPage']);
Route::get('/item/{id}/buy', [ItemController::class, 'addItemToCart']);
Route::get('/item/{id}/delete', [ItemController::class, 'removeItemFromCart']);

// Cart
Route::get('/cart', [ItemController::class, 'cartPage'])->name('cart');
Route::get('/checkout', [ItemController::class, 'checkoutPage'])->name('checkout');

// Admin
Route::get('/admin', [AdminController::class, 'adminPage'])->name('admin');
Route::get('/admin/changeRole', [AdminController::class, 'changeRolePage'])->name('adminChangeRole');
Route::post('/admin/changeRole', [AdminController::class, 'changeRole']);
Route::get('/admin/deleteUser', [AdminController::class, 'deleteUser'])->name('adminDelete');
