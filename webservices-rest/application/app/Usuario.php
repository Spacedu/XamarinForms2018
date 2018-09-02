<?php

namespace App;


use Illuminate\Database\Eloquent\Model;
use Illuminate\Auth\Authenticatable;
use Illuminate\Auth\Passwords\CanResetPassword;
use Illuminate\Contracts\Auth\Authenticatable as AuthenticatableContract;
use Illuminate\Contracts\Auth\CanResetPassword as CanResetPasswordContract;

class Usuario extends Model implements AuthenticatableContract, CanResetPasswordContract{
    use Authenticatable, CanResetPassword;
    
    protected $table = 'ws_xf2018_usuario';
    protected $fillable = ['nome', 'password'];
    
    public function mensagens(){
        $this->hasMany('App\Mensagem');
    }
    
}