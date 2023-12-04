è
qC:\Users\obeth\Downloads\ServidorMemoramaLis_Servidor\InicioDeSesionService.Contracts\IAutentificacionServicio.cs
	namespace		 	
ServidorMemoramaLis		
 
.		 
	Contracts		 '
{

 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /,
 IAutentificacionServicioCallBack/ O
)O P
)P Q
]Q R
public 

	interface $
IAutentificacionServicio -
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void "
AutentificacionUsuario #
(# $
String$ *
usuario+ 2
,2 3
String4 :
contrasenia; F
)F G
;G H
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
RegistroJugador 
( 
JugadoresDTO )
jugador* 1
)1 2
;2 3
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
ValidacionDeEmail 
( 
String %
correo& ,
), -
;- .
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
UsuarioExistente 
( 
string $
usuario% ,
,, -
string. 4
correo5 ;
); <
;< =
} 
public 

	interface ,
 IAutentificacionServicioCallBack 5
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void $
RespuestaAutentificacion %
(% &
JugadoresDTO& 2
jugador3 :
): ;
;; <
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void   
RespuestaEmail   
(   
string   "
codigoVerificac√≠on  # 5
)  5 6
;  6 7
["" 	
OperationContract""	 
("" 
IsOneWay"" #
=""$ %
true""& *
)""* +
]""+ ,
void## 
Respuestaregistro## 
(## 
bool## #
estado##$ *
)##* +
;##+ ,
[$$ 	
OperationContract$$	 
($$ 
IsOneWay$$ #
=$$$ %
true$$& *
)$$* +
]$$+ ,
void%% %
RespuestaUsuarioExistente%% &
(%%& '
bool%%' +
status%%, 2
)%%2 3
;%%3 4
}&& 
}'' …
fC:\Users\obeth\Downloads\ServidorMemoramaLis_Servidor\InicioDeSesionService.Contracts\IServicioChat.cs
	namespace		 	
ServidorMemoramaLis		
 
.		 
	Contracts		 '
{

 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /!
IServicioChatCallBack/ D
)D E
)E F
]F G
public 

	interface 
IServicioChat "
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
UnirseAChat 
( 
string 
nombreUsuario  -
,- .
string. 4
codigoDeChat5 A
)A B
;B C
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
EnviarMensaje 
( 
string !
mensaje" )
,) *
string+ 1
nombreUsuario2 ?
,? @
stringA G
codigoDeChatH T
)T U
;U V
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SalirDelChat 
( 
string  
nombreDeUsuario! 0
,0 1
string2 8
codigoDeChat9 E
)E F
;F G
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
	CrearChat 
( 
string 
codigoDeChat *
)* +
;+ ,
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 

BorrarChat 
( 
string 
codigoDeChat +
)+ ,
;, -
} 
public 

	interface !
IServicioChatCallBack *
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
RecibirMensaje 
( 
string "
nombreJugador# 0
,0 1
string2 8
mensaje9 @
)@ A
;A B
} 
} Õ,
iC:\Users\obeth\Downloads\ServidorMemoramaLis_Servidor\InicioDeSesionService.Contracts\IServicioPartida.cs
	namespace

 	
ServidorMemoramaLis


 
.

 
	Contracts

 '
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /$
IServicioPartidaCallBack/ G
)G H
)H I
]I J
public 

	interface 
IServicioPartida %
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
UnirseAPartida 
( 
JugadoresDTO (
jugador) 0
,0 1
string2 8
codigoDePartida9 H
)H I
;I J
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
EnviarMovimiento 
( 
string $

movimiento% /
,/ 0
string1 7
nombreUsuario8 E
,E F
stringG M
codigoDePartidaN ]
)] ^
;^ _
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SalirDePartida 
( 
string "
nombreDeUsuario# 2
,2 3
string4 :
codigoDePartida; J
)J K
;K L
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
CrearPartida 
( 
string  
codigoDePartida! 0
)0 1
;1 2
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
BorrarPartida 
( 
string !
codigoDePartida" 1
)1 2
;2 3
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
ContarJugadores 
( 
string #
codigoDePartida$ 3
)3 4
;4 5
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
IniciarJuego 
( 
string  
codigoDePartida! 0
)0 1
;1 2
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void   
ReportarJugador   
(   
string   #
nombreDeUSuario  $ 3
,  3 4
string  5 ;
codigoDePartida  < K
)  K L
;  L M
void!! 
TerminarPartida!! 
(!! 
string!! #
codigoDePartida!!$ 3
)!!3 4
;!!4 5
}"" 
public## 

	interface## $
IServicioPartidaCallBack## -
{$$ 
[%% 	
OperationContract%%	 
(%% 
IsOneWay%% #
=%%$ %
true%%& *
)%%* +
]%%+ ,
void&& 
RecibirTablero&& 
(&& 

Dictionary&& &
<&&& '
int&&' *
,&&* +
string&&, 2
>&&2 3
tablero&&4 ;
)&&; <
;&&< =
['' 	
OperationContract''	 
('' 
IsOneWay'' #
=''$ %
true''& *
)''* +
]''+ ,
void(( 
RecibirMovimiento(( 
((( 
string(( %
nombreJugador((& 3
,((3 4
string((5 ;

movimiento((< F
)((F G
;((G H
[)) 	
OperationContract))	 
()) 
IsOneWay)) #
=))$ %
true))& *
)))* +
]))+ ,
void** 
ExpulsarJugador** 
(** 
string** #
nombreJugador**$ 1
)**1 2
;**2 3
[++ 	
OperationContract++	 
(++ 
IsOneWay++ #
=++$ %
true++& *
)++* +
]+++ ,
void,, #
ObtenerListaDeJugadores,, $
(,,$ %
List,,% )
<,,) *
JugadoresDTO,,* 6
>,,6 7
	jugadores,,8 A
),,A B
;,,B C
[-- 	
OperationContract--	 
(-- 
IsOneWay-- #
=--$ %
true--& *
)--* +
]--+ ,
void.. #
ObtenerJugadorReportado.. $
(..$ %
bool..% )
estado..* 0
)..0 1
;..1 2
[// 	
OperationContract//	 
(// 
IsOneWay// #
=//$ %
true//% )
)//) *
]//* +
void00 %
RespuestaDeUnirseAPartida00 &
(00& '
string00' -
codigoDeRespuesta00. ?
)00? @
;00@ A
[11 	
OperationContract11	 
(11 
IsOneWay11 #
=11$ %
true11& *
)11* +
]11+ ,
void22 "
MostrarTerminarPartida22 #
(22# $
List22$ (
<22( )
string22) /
>22/ 0
	ganadores221 :
,22: ;
int22< ?
puntos22@ F
)22F G
;22G H
}33 
}44 õ
pC:\Users\obeth\Downloads\ServidorMemoramaLis_Servidor\InicioDeSesionService.Contracts\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str :
): ;
]; <
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str <
)< =
]= >
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *