<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the controller to call when that URI is requested.
|
*/

Route::get('/', function () {
    return view('welcome');
});
Route::group(['prefix' => 'api'], function () {
    Route::post('/usuario', "WS\RestServiceController@Usuario");
    
    Route::get('/chats', "WS\RestServiceController@GetChats");
    Route::post('/chat', "WS\RestServiceController@InsertChat");
    Route::put('/chat/{chatId}', "WS\RestServiceController@RenomearChat");
    Route::delete('/chat/delete/{chatId}', "WS\RestServiceController@DeleteChat");
    
    Route::get('/chat/{chatId}/msg', "WS\RestServiceController@GetMensagens");
    Route::post('/chat/{chatId}/msg', "WS\RestServiceController@InsertMensagem");
    Route::delete('/chat/{chatId}/delete/{msgId}', "WS\RestServiceController@DeleteMensagem");
});

Route::group(['prefix' => 'apix'], function () {
    Route::post('/token', "WS\RestJWTServiceController@GetToken");
    
    Route::get('/verify', "WS\RestJWTServiceController@Verify");
    
    Route::post('/tokenx', "WS\RestJWTServiceController@GetAutetication");
});
Route::get("/geo", function(){
    return '{"returnResult":[{"countryId":"8ed6fb35-c646-43ec-bb11-21f4d4665d9a","name":"Brazil","abbreviation":"BRA"}],"errors":[],"systemErrors":[],"time":"2018-05-23T10:05:28.2480431-03:00","success":true}';
});

/*
Route::group(['prefix' => 'api'], function () {
  Route::get('/values', "WS\RestServiceController@Index");
  Route::get('/value/{key}', "WS\RestServiceController@Get");
  Route::post('/values', "WS\RestServiceController@Insert");
  Route::put('/value/edit/{key}', "WS\RestServiceController@Update");
  Route::delete('/value/delete/{key}', "WS\RestServiceController@Delete");
});
*/