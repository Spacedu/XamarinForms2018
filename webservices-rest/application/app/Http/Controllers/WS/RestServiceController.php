<?php
namespace App\Http\Controllers\WS;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Usuario;
use App\Chat;
use App\Mensagem;

class RestServiceController extends Controller
{
    public function Usuario(Request $request){
        
        $nome = $request->input("nome");
        $password = $request->input("password");
        
        if(strlen($nome) > 0 & strlen($password) > 0){
            
            $usuario = Usuario::where("nome", $nome)->first();
            if($usuario == null){
                $model = Usuario::firstOrCreate(["nome"=>$nome, "password"=>$password]);
            }else{
                if($usuario->password == $password){
                    $model = $usuario;
                }else{
                    return response("Senha não confere", 400)->header('Content-Type', 'text/plain');;
                }
            }
            
            return response(json_encode($model), 200)->header('Content-Type', 'application/json');;
        }else{
            return response("Nome/Senha não informado(a)", 400)->header('Content-Type', 'text/plain');;
        }
    }
    
    public function GetChats(Request $request){
        return response(json_encode(Chat::All()), 200)->header('Content-Type', 'application/json');
    }
    public function InsertChat(Request $request){
        
        $nome = $request->input("nome");
        
        if(strlen($nome) > 0){
            $model = Chat::firstOrCreate(["nome"=>$nome]);
            return response(json_encode($model), 200)->header('Content-Type', 'application/json');
        }else{
            return response("Nome não informado", 400)->header('Content-Type', 'text/plain');
        }
    }
    
    public function RenomearChat(Request $request, $chatId){
        
        $nome = $request->input("nome");
        
        if(strlen($nome) > 0){
            $model = Chat::find($chatId);
            $model->nome = $nome;
            $model->save();
            
            return response(json_encode($model), 200)->header('Content-Type', 'application/json');
        }else{
            return response("Nome do chat não informado", 400)->header('Content-Type', 'text/plain');
        }
    }
    public function DeleteChat(Request $request, $chatId){
        $deleteRows = Chat::find($chatId)->delete();
        
        if($deleteRows == 1){
            return response(json_encode(array("status"=> "OK")), 200)->header('Content-Type', 'application/json');
        }else{
            return response("Chat não encontrado", 400)->header('Content-Type', 'text/plain');
        }
    }
    
    
    public function GetMensagens(Request $request, $chatId){
        $resultado = Mensagem::where("id_chat", $chatId)->with("usuario")->get();
        
        return response(json_encode($resultado), 200)->header('Content-Type', 'application/json');
    }
    
    public function InsertMensagem(Request $request, $chatId){
        
        $mensagem = $request->input("mensagem");
        
        if(strlen($mensagem) > 0){
            $model = new Mensagem();
            $model->mensagem = $mensagem;
            $model->id_chat = $chatId;
            $model->id_usuario = $request->input("id_usuario");
            $model->save();
            
            return response(json_encode($model), 200)->header('Content-Type', 'application/json');
        }else{
            return response("Mensagem não informada", 400)->header('Content-Type', 'text/plain');
        }
    }
    
    public function DeleteMensagem(Request $request, $chatId, $msgId){
        $deleteRows = Mensagem::find($msgId)->delete();
        
        if($deleteRows == 1){
            return response(json_encode(array("status"=>"OK")), 200)->header('Content-Type', 'application/json');
        }else{
            return response("Mensagem não encontrada", 400)->header('Content-Type', 'text/plain');
        }
    }
    
    
}