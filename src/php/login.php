<?php
session_start();
require_once("./config.php");

if(!isset($_GET['user'])) {
	die("Please make a request.");
}
if(!isset($_GET['site'])) {
	die("Please choose a service");
}

$requestedSite = $_GET['site'] - 1;
$requestedUser = $_GET['user'] - 1;

$site_url = $sites[$requestedSite]['url_login'];
$site_front = $sites[$requestedSite]['url_front'];
$user_field = $sites[$requestedSite]['user_field'];
$pass_field = $sites[$requestedSite]['pass_field'];
$remember_field = $sites[$requestedSite]['remember_field'];
$special_pass = $sites[$requestedSite]['password'];
$post_data = $sites[$requestedSite]['post_data'];

$username = $users[$requestedUser]['user'];

switch($special_pass) {
	case "md5":
	$password = md5($users[$requestedUser]['pass']);
	break;
	case "sha1":
	$password = sha1($users[$requestedUser]['pass']);
	break;
	default:
	$password = $users[$requestedUser]['pass'];
}

$data = array($user_field => $username, $pass_field => $password, $remember_field => '0');

$data = $post_data . "$user_field=$username&$pass_field=$password&$remember_field=1";

//die($data);

$ch = curl_init();

curl_setopt($ch, CURLOPT_URL, $site_url);
curl_setopt($ch, CURLOPT_USERAGENT, "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)");
curl_setopt($ch, CURLOPT_COOKIEJAR, "./codecall_" . SID . ".txt");
curl_setopt($ch, CURLOPT_COOKIEFILE, "./codecall_" . SID . ".txt");
curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 0);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 7);
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $data);

$exec = curl_exec($ch);

curl_close($ch);

$pos = strpos($exec, "Thank you for logging in");
if($pos === FALSE) {
	echo "NOLOGIN";
}
else {
	echo "LOGGEDIN";
}
?>