$(document).ready(()=>{
    const BASE_URL = "http://localhost:8000/api/v1";

    $('#loginBtn').click(handleClickLogin);



    
    // functions
    function handleClickLogin(e){
        e.preventDefault();
        let reqBody = {
            Email: $('#email').val(),
            Password: $('#password').val()
        };
        console.log(reqBody);
        console.log('clicked');
        $.ajax({
            url: `${BASE_URL}/auth/login`,
            method: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(reqBody),
            success: handleLoginSuccess,
            error: handleLoginError
        });

        function handleLoginSuccess(data){
            console.log(data);
            storeJwt(data.Token, data.UserId);
            window.location.href = "../index.html";
            
        }
        function handleLoginError(error){
            console.log(error);
            if(error.status === 400){
                $(".login-error").text("Invalid Credentials");
            }
        }
    }

    function storeJwt(token, UserId){
        localStorage.setItem("jwt-token", token);
        localStorage.setItem("UserId", UserId);

    }
})


