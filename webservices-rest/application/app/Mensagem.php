<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Mensagem extends Model {
    protected $table = 'ws_xf2018_messagem';
    protected $fillable = ['mensagem'];
    
    
    public function usuario() {
        return $this->belongsTo('App\Usuario', 'id_usuario');
    }
    /*
    public function chat(){
        return $this->belongsTo('App\Chat', 'id_chat', 'id');
    }*/
}