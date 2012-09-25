<?php
session_start();
if(!isset($_GET['url'])) { die("Please define an URL."); }

$url = $_GET['url'];

$ch = curl_init();

curl_setopt($ch, CURLOPT_URL, $url);
curl_setopt($ch, CURLOPT_USERAGENT, "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)");
curl_setopt($ch, CURLOPT_COOKIEJAR, "./codecall_" . SID . ".txt");
curl_setopt($ch, CURLOPT_COOKIEFILE, "./codecall_" . SID . ".txt");
curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 7);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

$exec = curl_exec($ch);

curl_close($ch);

echo $exec;
?>