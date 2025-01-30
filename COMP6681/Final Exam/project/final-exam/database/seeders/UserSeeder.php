<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('users')->insert([
            'role_id' => 1,
            'gender_id' => 1,
            'first_name' => 'admin',
            'last_name' => 'admon',
            'email' => 'admin@admin.com',
            'display_picture_link' => '/pfp/avatar.png',
            'password' => bcrypt('admin'),
        ]);
    }
}
