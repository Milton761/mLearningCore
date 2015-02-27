

$(document).ready(function() {
	
	
	var selected="";
	
		  				
				/*------------------------------------------------
				To edit your form heading
				-------------------------------------------------*/
				// titulo principal
				$("#maintitle").click(function(){
					$("#your").hide();            
						var createhead=$(document.createElement('div'));
						createhead.attr("id","your1");
						createhead.html('<label id="titleid">'+
						'<b>TITULO	 : </b>'+
						'</label>'+
						'<br/>'+
						'<input id="inputhead" "type=text placeholder="Ingrese el titulo de su presentacion" required/>'+
						'<button id="doneid">Aceptar</button>');
					    $("#yourhead").append(createhead);
						var get1=$("#maintitle").text();
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
						$("#maintitle").html('<h1>'+get+'</h1>');  
						$("#maintitle").css({"text-align":"center","font-size":"12px","color":"#8A8A8A","cursor":"pointer"});
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
var nameFieldCount=0;




// text header
/*nomenclatura
   - txttitle[n]
   -txtimage[n]
*/
				var MaxInputs = 100; //Maximum input boxes allowed
                /*----------------------------------
				to keep track of fields and divs added
				-----------------------------------*/
				var InputsWrapper = $("#InputsWrapper"); //Input box wrapper ID
				var x = InputsWrapper.length; //Initial field count
                $(InputsWrapper).sortable();  		// to make added fields sortable
			/*------------------------------------------------------------------------------
			HEADER
			*/	
			$("#Header").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="name" id="InputsWrapper_0' + nameFieldCount + '">'+
												'<div id="numero"><label class="numero1">' + i + '</label></div>'+
												'<div id="object"><br/>'+
												'<table width="10%"><tr><td>'+
												'<input class="ingreso" type="text" name="header" id="txtheader'+i+'"  placeholder="TITULO DEL TEXTO" value=""/></td><td style="width:180px;">'+
												'<input style="width:95%;"  type="image" name="imageField" class="picture" id="imgheader'+i+'" src="images/iconimage.png"></td>'+
												'</tr></table></div> '+
												'<button class="rmheader bremove" id="hd'+i+'">x</button>'+
												'</div>');
						
						headers.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmheader", function() {   //to remove name field
					
					//alert($(this).attr("id"));
					//str.substring(1, 4);
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, headers);
					if (posicion > -1) {
 					   headers.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
					//alert(headers.toString());
                    return false;
                });
				
				
				
				

		
		/*
		------------------------------------------------------------------------------
		TEXT
		*/
		
		
		$("#Text").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="texto" id="InputsWrapper_0' + nameFieldCount + '">'+
								'<div id="numero"><label class="numero2">' + i + '</label></div>'+
								'<div id="object"><div class="tituloText">'+
								'<input class="ingreso" type="text" id="titletext'+i+'"  placeholder="TITULO DEL TEXTO" value=""/>'+
								'</div><div>'+
								'<textarea rows="6" class="ingreso" id="txttext'+i+'"  placeholder="ingrese contenido del texto"></textarea>'+
												'</div></div><button class="rmtext bremove" id="tx'+i+'">x</button></div>');
						
						texts.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmtext", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, texts);
					if (posicion > -1) {
 					   texts.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				
		
		
		
		/*
		BULLETS
		*/
		

		
		$("#Bullets").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="texto" id="InputsWrapper_0' + nameFieldCount + '">'+
												'<div id="numero"><label class="numero3">' + i + '</label></div>'+
												'<div id="object"><div class="tituloText">'+
												'<input type="text" class="ingreso" id="titlebullet'+i+'"  placeholder="Ingrese el titulo de la lista" value=""/>'+
												'</div><div>'+
												'<textarea rows="6" class="bullet" id="lineas'+i+'"  placeholder="ingrese la lista"></textarea>'+
												'</div></div><button class="rmbullets bremove" id="bl'+i+'">x</button></div>');
						
						bullets.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmbullets", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, bullets);
					if (posicion > -1) {
 					   bullets.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				
				
				
				
				/*
				COLUMNAS
				*/
		
		$("#Columns").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="columnas" id="InputsWrapper_0' + nameFieldCount + '">'+
												'<div id="numero"><label class="numero4">' + i + '</label></div>'+
												'<div id="object">'+
												'<table border="0" cellpadding="0" class="tablacolumnas"><tr>'+
												'<td width="33%"><input type="image" style="width:170px;"  class="picture" name="imageField" id="imgcol1'+i+'" src="images/iconimage2.png"></td>'+
												'<td width="33%"><input type="image"  style="width:170px;" class="picture" name="imageField" id="imgcol2'+i+'" src="images/iconimage2.png"></td>'+
												'<td><input type="image" name="imageField"  style="width:170px;" class="picture" id="imgcol3'+i+'" src="images/iconimage2.png"></td>'+
											    '</tr><tr>'+
												'<td><input class="imputcolumn" type="text" id="txtcol1'+i+'" placeholder="Ingrese el titulo" value="" width="50px"/></td>'+
												'<td><input class="imputcolumn" type="text" id="txtcol2'+i+'" placeholder="Ingrese el titulo" value=""/></td>'+
												'<td><input class="imputcolumn" type="text" id="txtcol3'+i+'" placeholder="Ingrese el titulo" value=""/></td>'+
												'</tr></table>'+
												'</div><button class="rmcolumns bremove" id="cl'+i+'">x</button></div>');
						
						columns.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmcolumns", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, columns);
					if (posicion > -1) {
 					   columns.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				
		
		/*Quote*/

		
		$("#Quote").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="columnas" id="InputsWrapper_0' + nameFieldCount + '">'+
						'<div id="numero"><label class="numero5">' + i + '</label></div>'+
												'<div id="object"><div class="tituloText">'+
												'<table border="0" width="100%" cellpadding="0" class="tablacolumnas"><tr>'+
												'<td><input class="ingreso" type="text" id="txtquote'+i+'" placeholder="Ingrese el titulo" value=""/></td>'+
												'<td rowspan="2" width="170px"><input style="width:150px;" class="picture" type="image" id="imgquote'+i+'"  src="images/icon11.png"></td>'+
											 	'</tr><tr>'+
												'<td><textarea rows="6"   class="ingreso" id="detailquote'+i+'"  placeholder="ingrese la lista"></textarea></td>'+
											  	'</tr></table>'+
												'</div></div><button class="rmquotes bremove" id="qu'+i+'">x</button></div>');
						
						quotes.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmquotes", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, quotes);
					if (posicion > -1) {
 					   quotes.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				
		
		
		
		
		/*        IMAGE
		*/
		
		
		$("#Image").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="imagen" id="InputsWrapper_0' + nameFieldCount + '">'+
												'<div id="numero"><label class="numero1">' + i + '</label></div>'+
												'<div id="object"><div class="tituloText">'+
												'<input type="text" id="txtimage'+i+'" class="ingreso" placeholder="Ingrese un titulo opcional" value=""/><br/>'+
												'<br/><input type="image" class="picture" id="imgimage'+i+'" width="150px" src="images/iconimage.png">'+
												'</div></div><button class="rmimage bremove" id="im'+i+'">x</button></div>');
						
						imgs.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmimage", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, imgs);
					if (posicion > -1) {
 					   imgs.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				

		/*   veideos*/
		
		
		$("#Video").click(function()  		
                {
                    if (x <= MaxInputs) 		
                    {
                        nameFieldCount++; 			
                        $(InputsWrapper).append('<div class="video" id="InputsWrapper_0' + nameFieldCount + '">'+
												'<div id="numero"><label class="numero2">' + i + '</label></div>'+
												'<div id="object"><div class="tituloText">'+
												'<input type="text" class="ingreso" id="txtvideo'+i+'" placeholder="Ingrese un titulo opcional" value=""/><br/>'+
												//'<input type="image" id="imgvideo'+i+'" src="images/icon11.png">'+
												'<iframe id="urlvideo1'+i+'" height="240px" width="240px"'+
												'src="http://www.youtube.com/embed/XGSy3_Czz8k">'+
												'</iframe>'+
												'</div></div><button class="rmvideo bremove" id="vi'+i+'">x</button></div>');
						
						videos.push(i.toString());
					    i++; 
                    }
                    return false;
                });
				// para eliminar
				$("body").on("click", ".rmvideo", function() {   //to remove name field text item
					var el=$(this).attr("id");
					    var a= el.substr(2,el.length-2);
						var posicion=jQuery.inArray(a, videos);
					if (posicion > -1) {
 					   videos.splice(posicion, 1);
					   $(this).parent('div').remove(); 
					}
                    return false;
                });
				
		
		
		// para la modificacion de imagenes
		
		
	var dialog, form
    function addUser() 
	{
    //  var valid = true;
      dialog.dialog( "close" );
		var a=$('#blah').attr('src');
		//a= a.replace("file:///","");
	  $("#"+selected).attr("src",a);

//	  return $('#imgInp').val();
	  return true;
    }
   dialog = $( "#dialog-form" ).dialog({
      autoOpen: false,
      height: 400,
      width: 450,
      modal: true,
      buttons: {
        "Aceptar": addUser,
        Cancel: function() {
          dialog.dialog( "close" );
        }
      }
    });

	function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            
            reader.onload = function (e) {
                $('#blah').attr('src', e.target.result);
				
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
    $("#imgInp").change(function()
	{
        readURL(this);
		
    });
	$( "#tabs" ).tabs();
		
		
		
		
		/* modificacion de imagenes*/ 
				$("body").on("click", ".picture", function() {   //to remove name field text item
					var el=$(this).attr("id");
					   // $("#"+el).attr("src","images/icon-09.png");
						//alert($("#"+el).attr("src"));
						 //$('#imgInp').val("");
						   selected= el;
					      dialog.dialog( "open" );
						  
		                  return true;
					
                });

		
		
			$("#PChart").click(function()  		
                {
					/*var item= "txtheader"+headers[0];
					alert(item);
					alert($("#"+item).val());*/
					//var a=parsehtml();
					var a=xmlparser(headers,varsheader);
					var b=xmlparser(texts,varstxt);
					var c=xmlparser(bullets,varsbullet);
					var d=xmlparser(columns,varscolumns);
					var e=xmlparser(quotes,varsquote);
					var f=xmlparser(imgs,varsimg);
					var g=xmlparser(videos,varsvideo);
					
					var xmlfinal=a.ToString()+b.ToString()+c.ToString()+d.ToString()+e.ToString()+f.ToString()+g.ToString();
					//$("#xml").val(xmlfinal);
					savefile(xmlfinal,"D:/xmlgenerado.xml");
					alert("Xml Generado Exitosamente");
					msg =  "I am the president of tautology club.";
				savefile(msg, "C:\\test");
				});
		
		function savefile(content, filename){
    var dlg = false;
    with(document){
     ir=createElement('iframe');
     ir.id='ifr';
     ir.location='about.blank';
     ir.style.display='none';
     body.appendChild(ir);
      with(getElementById('ifr').contentWindow.document){
           open("text/plain", "replace");
           charset = "utf-8";
           write(content);
           close();
           document.charset = "utf-8";
           dlg = execCommand('SaveAs', false, filename);
       }
       body.removeChild(ir);
     }
    return dlg;
}
		
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
							campo=val.substring(0, 3)=="img"?"oimagen":
								  val.substring(0, 3)=="txt"?"texto":
								  val.substring(0, 3)=="det"?"detalle":
								  val.substring(0, 3)=="lin"?"lineas":
								  val.substring(0, 3)=="url"?"ovideo":"titulo";
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

	



			