<?php
    /*function print_response($dict = [], $error = "none"){
        $response = "{\"error\" : \"$error\", \"response\" : ". json_encode($dict) ."}";
        echo $response;
    }

    $str = "{
        \"result\" : \"kasumiii\",
        \"afterglow\" : \"rann\"
    }";

    echo $str;
    
    foreach($result as $row)
    {
        echo $row["yo"];
        echo $row["nani"];
    }
    echo "fuckk";
    die;*/
    function connect_db()
    {
        $host_name = "localhost";
        $db_name = "cpekmut1_slave_server";
        $username = "cpekmut1_ein";
        $password = "123456";

        try{
            $pdo = new PDO("mysql:host=$host_name;dbname=$db_name;charset=utf8", $username, $password);
            $pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            return $pdo;
        }
        catch(\PDOException $e){
            /*$reply = "{\"Reply\" : \"Error\", \"Text\" : \"$e\"}";
            echo $reply;*/
            return null;
        }
    }

    //$data = json_decode($_REQUEST["data"], true);
    /*$reply = "{\"Reply\" : \"Error\"}";
    echo $reply;
    foreach($data as $row)
    {
        echo $row;
    }
    $reply = "{\"Reply\" : \"Test\", \"Text\" : \"$data\"}";
    echo $reply;*/
    //echo $data["Request"];
    //$wtf = $data["Request"]
    //$reply = "{\"Reply\" : ".$wtf."}";
    //echo json_encode($data);

    /*
    switch($data["Request"]){
        case "Test":
            $sth = $pdo -> prepare("SELECT * FROM test");
            $sth -> execute();
            $query = $sth -> fetchAll();
            $reply = "{\"Reply\" : \"Test\", \"Data\" : ".json_encode($query)."}";
            echo $reply;
            die;
        break;

        default:
            $data = json_decode($_REQUEST["data"], true);
            $reply = "{\"Reply\" : \"Error\"}";
            echo $reply;
            die;
        break;
    }*/
?>