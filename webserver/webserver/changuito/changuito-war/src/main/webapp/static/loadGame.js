function load(){

	
    id = $("#id").val();
    $("#resultado").load("static/unityPlayer/unityPlayerLoader.jsp");
    
 /*   $.ajax({
        type: "POST",
        url: "static/unityPlayer/unityPlayerLoader.jsp",
        contentType: "application/json",
        data:id,
        async: false,
        success: function (data) {
            $("#resultado").html(data.d);
        }
    });*/
}