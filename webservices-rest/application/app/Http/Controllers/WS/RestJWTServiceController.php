<?php
namespace App\Http\Controllers\WS;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Usuario;
use App\Chat;
use App\Mensagem;
use JWTAuth;
use Hash;
use Tymon\JWTAuth\Exceptions\JWTException;

class RestJWTServiceController extends Controller
{
    public function GetToken(Request $request){
        // Get only email and password from request
      $credentials = $request->only('nome', 'password');

      // Get user by email
      $company = Usuario::where('nome', $credentials['nome'])->first();

      // Validate Company
      if(!$company) {
        return response()->json([
          'error' => 'Invalid credentials'
        ], 401);
      }

      // Validate Password
      if (!($credentials['password'] == $company->password)) {
          return response()->json([
            'error' => 'Invalid credentials'
          ], 401);
      }

        $token = JWTAuth::fromUser($company);
        
        
        $objectToken = JWTAuth::setToken($token);
        $expiration = JWTAuth::decode($objectToken->getToken())->get('exp');
        
        return response()->json([
            'access_token' => $token,
            'token_type' => 'bearer',
            'expires_in' => JWTAuth::decode($objectToken->getToken())->get('exp')
          ]);
          
    }
    
    protected function Verify()
    {
        try{
            $currentUser = JWTAuth::parseToken()->authenticate();
            if($currentUser != null){
                return response()->json(array("JWT"=>"Ativo", "usuario"=>$currentUser));
            }else{

            }
        }catch(JWTException $e){
            return response()->json(
                [
                    'error' => 'Token não enviado ou inválido!', 
                    "msg"=>$e->getMessage()
                ], 500);
        }
    }
    protected function GetAutetication(Request $request)
    {
          // Get only email and password from request
      $credentials = $request->only('nome', 'password');

      // Get user by email
      $company = Usuario::where('nome', $credentials['nome'])->first();

      // Validate Company
      if(!$company) {
        return response()->json([
          'error' => 'Invalid credentials'
        ], 401);
      }

      // Validate Password
      if (!($credentials['password'] == $company->password)) {
          return response()->json([
            'error' => 'Invalid credentials'
          ], 401);
      }

        $token = JWTAuth::fromUser($company);
        
        
        $objectToken = JWTAuth::setToken($token);
        $expiration = JWTAuth::decode($objectToken->getToken())->get('exp');
        
        
        
        return response()->json([
            'token' => 'OK'
          ])->header("Authorization", $token);
    }
}