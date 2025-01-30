<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ItemSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        for ($i = 0; $i < 100; $i++) {
            DB::table('items')->insert([
                [
                    'item_name' => fake()->words(3, true),
                    'item_desc' => fake()->sentences(4, true),
                    'price' => 1000
                ],
            ]);
        }
    }
}
