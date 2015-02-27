$(document).ready(function() {
		  				
				/*------------------------------------------------
				To edit your form heading
				-------------------------------------------------*/
				// titulo principal
				$("#titlequiz").click(function(){
					$("#your").hide();            
						var createhead=$(document.createElement('div'));
						createhead.attr("id","your1");
						createhead.html('<label id="titleid">'+
						'<b>TITULO	 : </b>'+
						'</label>'+
						'<br/>'+
						'<input id="inputhead" "type=text placeholder="INGRESE EL TITULO DEL QUIZ" required/>'+
						'<button id="doneid">Aceptar</button>');
					    $("#yourhead").append(createhead);
						var get1=$("#titlequiz").text();
						$("#inputhead").val(get1);  
						
						// boton done
						
					$("#doneid").click(function(){  
						var get=$("#inputhead").val(); 
						if(get==0)
						{
						alert("Coloque algun titulo");
						}
						else
						{
						$("#titlequiz").html('<h1>'+get+'</h1>');  
						$("#titlequiz").css({"text-align":"center","font-size":"12px","color":"#8A8A8A","cursor":"pointer"});
						$("#your1").remove();
						$("#your").show();   
						$("#your").css({"width":"80%"});
						$("#justclickid").hide(); 
						}
				    });
				});
	
/*----------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------*/
// Funciones de crecion de objetos
/*----------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------*/
var elements=[];
var headers=[];
var texts=[];
var bullets=[];
var columns=[];
var quotes=[];
var imgs=[];
var videos=[];
var i=1;
// definicion de variables el primer elemento es en nombre
var varsheader = ["header","txtheader", "imgheader"];
var varstxt = ["text","titletext", "txttext"];
var varsbullet = ["bullet","titlebullet", "lineas"];
var varscolumns = ["columns","imgcol1", "imgcol2","imgcol3", "txtcol1","txtcol2","txtcol3"];
var varsquote = ["quote","txtquote", "detailquote","imgquote"];
var varsimg=["imagen","imgimage","txtimage"];
var varsvideo=["video","urlvideo","txtvideo"];





// text header
/*nomenclatura
   - txttitle[n]
   -txtimage[n]
*/
				var MaxInputs = 100; //Maximum input boxes allowed
                /*----------------------------------
				to keep track of fields and divs added
				-----------------------------------*/
				var it = 1; 
				
				var InputsWrapper = $("#InputsWrapper"); //Input box wrapper ID
				var x = InputsWrapper.length; //Initial field count
                
                $(InputsWrapper).sortable();  		// to make added fields sortable
				
				
				
				
			/*------------------------------------------------------------------------------
			Quiz Free
			*/	
			$("#free").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                      $(InputsWrapper).append('<div class="freequiz" id="InputsWrapper_0' + it + '">'+
									'<div id="numero"><label class="numero2">' + it + '</label></div>'+
									'<div id="object"><input type="hidden" id="tipo"'+it+' value="free">'+
									'<table width="100%" border="0" cellpadding="0" cellspacing="0">'+
									'<tbody><tr><td colspan="3">'+
									'<label for="textarea">Titulo:</label>'+
									' <input type="text"  class="ingreso" id="title"'+it+' value=""></br>'+
									'<label for="textarea">Text Area:</label>'+
									'<textarea rows="3" class="ingreso" id="preg"'+it+' name="preg"'+it+'></textarea>'+
									'</td></tr><tr>'+
									'<td width="30%"><input type="image" name="imageField"  style="width:170px;" class="picture" id="img'+it+'" src="images/iconimage2.png"></td>'+
									'<td  colspan="2"><label for="textfield">Type of answers:</label>'+
									'<input type="text" class="ingreso" name="textfield" id="textfield"></td>'+
									'</tr></tbody></table></div>'+
									'<button class="rmheader bremove" id="hd'+it+'">x</button>'+
									'</div>');
						elements.push(it.toString());
                        it++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmheader", function() {   //to remove name field
					var el=$(this).attr("id");
					    
					   $(this).parent('div').remove(); 
	                    return false;
                });
				
				
				
				

		
		/*
		------------------------------------------------------------------------------
		Single Quiz
		*/
		
		
		$("#single").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                      $(InputsWrapper).append('<div class="singlequiz" id="InputsWrapper_0' + it + '">'+
									'<div id="numero"><label class="numero2">' + it + '</label></div>'+
									'<div id="object"><input type="hidden" id="tipo'+it+'" value="single">'+
									'<table width="100%" border="0" cellpadding="0" cellspacing="0">'+
									'<tbody><tr><td colspan="3">'+
									'<label for="textarea">Titulo:</label>'+
									' <input type="text"  class="ingreso" id="title"'+it+' value=""></br>'+
									'<label for="textarea">Text Area:</label>'+
									'<textarea rows="3" class="ingreso" id="preg"'+it+' name="preg"'+it+'></textarea>'+
									'</td></tr><tr>'+
									'<td width="30%"><input type="image" name="imageField"  style="width:170px;" class="picture" id="img'+it+'" src="images/iconimage2.png"></td>'+
									'<td  colspan="2"><label for="textfield">Numero Items:</label>'+
									'<input width="40" value="0" type="number" class="numeroitems" name="items'+it+'" id="is'+it+'" >'+
									'<div id="itemssingle'+it+'" class="is'+it+'"></div></td>'+
									'</tr></tbody></table></div>'+
									'<button class="rmheader bremove" id="hd'+it+'">x</button>'+
									'</div>');
						elements.push(it.toString());
                        it++; 
                    }
                    return false;
                });
				// para eliminar

				$("body").on("change", ".numeroitems", function() {   //to remove name field text item
				   var el=$(this).attr("id");
				     $( "."+el).empty();
					var nro=$("#"+el).val();
					//alert(nro);
					var  items= createradios(nro,"s"+nro,"s_"+nro);
					$( "."+el ).append( items );
					//alert(el);
                });
				
				
				function createradios(numero, id,nombre)
				{
					var a=1;
					var cadena='<p>';
					while (a<=numero)
					{
					 cadena+= '<input type="radio" id="'+nombre+a+'" value="'+a+'" name="'+nombre+'"><input  class="imputq" id=i"'+id+a+'" value="" type="text"></br>';
					 a++;
					}
					//alert(cadena);
					return cadena;
				}
		
		/*
		BULLETS
		*/
		

		
		$("#multiple").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                         $(InputsWrapper).append('<div class="singlequiz" id="InputsWrapper_0' + it + '">'+
									'<div id="numero"><label class="numero2">' + it + '</label></div>'+
									'<div id="object"><input type="hidden" id="tipo'+it+'" value="single">'+
									'<table width="100%" border="0" cellpadding="0" cellspacing="0">'+
									'<tbody><tr><td colspan="3">'+
									'<label for="textarea">Titulo:</label>'+
									' <input type="text"  class="ingreso" id="title"'+it+' value=""></br>'+
									'<label for="textarea">Text Area:</label>'+
									'<textarea rows="3" class="ingreso" id="preg"'+it+' name="preg"'+it+'></textarea>'+
									'</td></tr><tr>'+
									'<td width="30%"><input type="image" name="imageField"  style="width:170px;" class="picture" id="img'+it+'" src="images/iconimage2.png"></td>'+
									'<td  colspan="2"><label for="textfield">Numero Items:</label>'+
									'<input width="40" value="0" type="number" class="cnumeroitems" name="items'+it+'" id="is'+it+'" >'+
									'<div id="itemssingle'+it+'" class="is'+it+'"></div></td>'+
									'</tr></tbody></table></div>'+
									'<button class="rmheader bremove" id="hd'+it+'">x</button>'+
									'</div>');
						elements.push(it.toString());
                        it++; 
                    }
                    return false;
                });
				// para eliminar
				
				$("body").on("change", ".cnumeroitems", function() {   //to remove name field text item
				   var el=$(this).attr("id");
				     $( "."+el).empty();
					var nro=$("#"+el).val();
					//alert(nro);
					var  items= createCheck(nro,"m"+nro,"m_"+nro);
					$( "."+el ).append( items );
					//alert(el);
                });
				
				
				function createCheck(numero, id,nombre)
				{
					var a=1;
					var cadena='<p>';
					while (a<=numero)
					{
					 cadena+= '<input type="checkbox" id="'+nombre+a+'" value="'+a+'" name="'+nombre+'"><input  class="imputq" id=i"'+id+a+'" value="" type="text"></br>';
					 a++;
					}
					//alert(cadena);
					return cadena;
				}
				
				
				/*
				Matching
				*/
		
		$("#pairs").click(function()  		
                {
                  if (x <= MaxInputs) 		
                    {
                         $(InputsWrapper).append('<div class="singlequiz" id="InputsWrapper_0' + it + '">'+
									'<div id="numero"><label class="numero2">' + it + '</label></div>'+
									'<div id="object"><input type="hidden" id="tipo'+it+'" value="single">'+
									'<table width="100%" border="0" cellpadding="0" cellspacing="0">'+
									'<tbody><tr><td colspan="3">'+
									'<label for="textarea">Titulo:</label>'+
									' <input type="text"  class="ingreso" id="title"'+it+' value=""></br>'+
									'<label for="textarea">Text Area:</label>'+
									'<textarea rows="3" class="ingreso" id="preg"'+it+' name="preg"'+it+'></textarea>'+
									'</td></tr><tr>'+
									'<td width="30%"><input type="image" name="imageField"  style="width:170px;" class="picture" id="img'+it+'" src="images/iconimage2.png"></td>'+
									'<td  colspan="2"><label for="textfield">Numero Items:</label>'+
									'<input width="40" value="0" type="number" class="cnumeroitems" name="items'+it+'" id="is'+it+'" >'+
									'<div id="itemssingle'+it+'" class="is'+it+'"></div></td>'+
									'</tr></tbody></table></div>'+
									'<button class="rmheader bremove" id="hd'+it+'">x</button>'+
									'</div>');
						elements.push(it.toString());
                        it++; 
                    }
                    return false;
                });
				// para eliminar
				
				
		
		/*Quote*/

		/* modificacion de imagenes*/ 
				$("body").on("click", ".picture", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    $("#"+el).attr("src","images/icon-09.png");
						//alert($("#"+el).attr("src"));
                    return true;
					
                });
		/*
		PARSE HTML
		
		
		*/
				
				
			function parsehtml()
			{
				/*var XML = new XMLWriter();*/
				return xmlparser(headers,varsheader);
				//XML.Close();
				//return XML;
			}
				
				
			/*------------------------------------------------
				creacion del xml 
			-------------------------------------------------*/
			
			function xmlparser(repo,vars)
			{
			// recorremos las variables del tipo, donde repo contiene los indices y vars la posicion donde se encuentra
			var XML = new XMLWriter();
				if (repo.length>0)
				{
					var nombre= vars[0];// recorremos todos los items del mismo tipo
					
					for (var i = 0, elemento; elemento = repo[i]; i++) 
					{
					  // creamos cada elemento del tipo
					  XML.BeginNode(nombre);
					  
					  // adicionamos elementos
						for (var j = 1, val; val = vars[j]; j++) 
						{
							campo=val.substring(0, 3)=="img"?"imagen":
								  val.substring(0, 3)=="txt"?"texto":
								  val.substring(0, 3)=="det"?"detalle":
								  val.substring(0, 3)=="lin"?"lineas":
								  val.substring(0, 3)=="url"?"video":"titulo";
						     var itm=val+elemento;
							 if (campo=="texto" || campo=="detalle" || campo =="lineas" || campo== "lineas" || campo=="titulo")
							 {
								valor=$("#"+itm).val();
								//alert(valor);
							 }
							 else 
							 {
								// alert(itm);
							  valor=$("#"+itm).attr("src");
							 }
							XML.Node(campo, valor);
						}
						// adicionamos el numerador
					  //alert(elemento);
					  XML.Node("posicion", ""+elemento);
					  XML.EndNode();
					}
						XML.Close();
				}
				return XML;
			}
				

				
				$("#reset").on("click", function() { //to reset all elements falta implementar

                    $("#InputsWrapper").empty();
                });
				
				
				
				
				
				
				
});

/*-----------------------------------------------------------------
-----------------------------------------------------------------
funciones de parseo 
/*-----------------------------------------------------------------*/
/*-----------------------------------------------------------------*/

	



			