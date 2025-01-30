<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    use HasFactory;
    protected $primaryKey = 'order_id';
    public $timestamps = false;

    public function item()
    {
        return $this->belongsTo(Item::class, 'item_id');
    }
}
