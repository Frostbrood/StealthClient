<?php
if(!isset($_GET['url'])) { die("Please define an URL!"); }
?>

<script language="JavaScript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>

<script language="JavaScript">
$.get("page.php?url=<?php echo $_GET['url']; ?>", function(data){
    //$("page").html(data);
	//document.write(data);
	/*
    $("a").each(function(){
        this.href = "load.php?url=" + this.href;
    });
	*/
	
	document.getElementById("page").innerHTML=data;
	
	var links=document.getElementsByTagName('a')
	for (var i=0;i<links.length;i++){ 
		links[i].href = "http://localhost/ac-web/load.php?url=" + links[i].href;
	}
	
	var content = document.getElementById("page").innerHTML;
	document.getElementById("page").innerHTML=null;
	
	document.write(content);
});
</script>

<div id="page" style="display:none;">
</div>