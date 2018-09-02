<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Chat extends Model {
    protected $table = 'ws_xf2018_chat';
    protected $fillable = ['nome'];
    
    public function Mensagens(){
        $this->hasMany('App\Mensagem');
    }
}