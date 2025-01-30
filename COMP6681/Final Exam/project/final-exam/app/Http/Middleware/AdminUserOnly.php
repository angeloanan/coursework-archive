<?php

namespace App\Http\Middleware;

use App\Models\User;
use Closure;
use Illuminate\Http\Request;
use Illuminate\Routing\Controllers\Middleware;

class AdminUserOnly
{
    /**
     * Handle an incoming request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \Closure(\Illuminate\Http\Request): (\Illuminate\Http\Response|\Illuminate\Http\RedirectResponse)  $next
     * @return \Illuminate\Http\Response|\Illuminate\Http\RedirectResponse
     */
    public function handle(Request $request, Closure $next)
    {
        // TODO: Check if logged in user is admin or not
        // Sanity check whether user has logged in or not
        if (auth()->check()) {
            $user = User::find(auth()->user()->account_id);
            if ($user->role->role_name == 'admin') {
                return $next($request);
            } else {
                return redirect()->route('allItem');
            }
        } else {
            return redirect()->route('login');
        }
    }
}
