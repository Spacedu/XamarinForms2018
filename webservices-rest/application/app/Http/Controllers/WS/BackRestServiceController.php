<?php
/*
namespace App\Http\Controllers\WS;

use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Storage;
use Illuminate\Http\Request;

class RestServiceController extends Controller
{
  public static $arquivo = "database.txt";
    public static $valores;
    public function Index(){

      self::$valores = $this->CarregarValores();

      return response()->json(self::$valores);
    }

    public function Get($key){
        self::$valores = $this->CarregarValores();

        return isset(self::$valores[$key]) ? self::$valores[$key] : response("Not found", 404);
    }

    public function Insert(Request $request){
      $key = $request->key;
      $value = $request->value;

      self::$valores = $this->CarregarValores();

      if( array_key_exists( $key, self::$valores ) ){
        return response("Chave já existe!", 400)->header('Content-Type', 'text/plain');;
      }else{
        self::$valores[$key] = $value;
        $this->SalvarValores();
        return response("OK", 200)->header('Content-Type', 'text/plain');;
      }
    }

    public function Update(Request $request, $key){

      $value = $request->value;

      self::$valores = $this->CarregarValores();

      if( array_key_exists( $key, self::$valores )){
        self::$valores[$key] = $value;

        $this->SalvarValores();
        return response("Atualizado", 200)->header('Content-Type', 'text/plain');;
      }else{
        return response("Chave não existe!", 400)->header('Content-Type', 'text/plain');;

      }
    }
    public function Delete( $key){
      self::$valores = $this->CarregarValores();

      if( array_key_exists( $key, self::$valores )){
        unset(self::$valores[$key]);

        $this->SalvarValores();
        return response("Removido", 200)->header('Content-Type', 'text/plain');
      }else{
        return response("Chave não existe!", 400)->header('Content-Type', 'text/plain');
      }
    }

    private function CarregarValores(){
      if(Storage::exists(self::$arquivo)){
         self::$valores = json_decode(Storage::get(self::$arquivo), true);
      }else{
         self::$valores = array();
      }
      return self::$valores;
    }
    private function SalvarValores(){
      Storage::put(self::$arquivo, json_encode(self::$valores));
    }
}

*/