$(document).ready(()=>{
    const BASE_URL = "http://localhost:8000/api/v1";

    $('#signupBtn').click(handleClickSignup);



    
    // functions
    function handleClickSignup(e){
        e.preventDefault();
        let reqBody = {
            FirstName: $('#firstName').val(),
            LastName: $('#lastName').val(),
            Email: $('#email').val(),
            Password: $('#password').val()
        };
        console.log(reqBody);
        console.log('clicked');
        $.ajax({
            url: `${BASE_URL}/auth/signup`,
            method: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(reqBody),
            success: handleSignupSuccess,
            error: handleSignupError
        });

        function handleSignupSuccess(data){
            console.log(data);
            window.location.href  = "../login/index.html";
        }
        function handleSignupError(error){
            console.log(error);
            if(error.status === 409){
                $(".signup-error").text("Email is Already registered");
            }
            if(error.status === 400){
                $(".signup-error").text("Credentials are required");
            }
        }

    }
})


