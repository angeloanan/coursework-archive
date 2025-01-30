<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use App\Models\Role;
use App\Models\Gender;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('users', function (Blueprint $table) {
            $table->id('account_id');

            $table->foreignIdFor(Role::class, 'role_id')->constrained('roles', 'role_id');
            $table->foreignIdFor(Gender::class, 'gender_id')->constrained('genders', 'gender_id');

            $table->string('first_name', 25);
            $table->string('last_name', 25);
            $table->string('email', 100);
            $table->string('display_picture_link', 100);
            $table->string('password');

            $table->rememberToken();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('users');
    }
};
