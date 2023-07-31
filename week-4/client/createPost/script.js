$(document).ready(() => {
    const BASE_URL = "http://localhost:8000/api/v1";

    // checking if the user is logged in or not
    let isLoggedIn = false;
    let jwt = localStorage.getItem("jwt-token");
    if (jwt !== null && jwt.length > 0) {
        isLoggedIn = true;
    } else {
        isLoggedIn = false;
    }
    if (!isLoggedIn) {
        $(".navItems-container").append(
            `
            <li>
                <a href="../signup/index.html">
                    Sign Up
                </a>
            </li>
            <li>
                <a href="../login/index.html">
                    Login
                </a>
            </li>
            `
        );
    } else {
        $(".navItems-container").append(
            `
            <li>
                <a class="signout-btn">
                    Sign Out
                </a>
            </li>
            `
        );
    }



    // signout btn functionality
    $(".signout-btn").click(hanldeClickSignout);
    function hanldeClickSignout() {
        localStorage.setItem("jwt-token", "");
        localStorage.setItem("UserId", null);
        location.reload();
    }

    if (isLoggedIn) {
        $(".create-post").empty();
        $(".create-post").append(
            `
            <div>
                <input type="text" id="title" placeholder="enter title">
            </div>
            <div>
                <textarea name="postBody" id="postBody" cols="30" rows="10" placeholder="enter post content"></textarea>
            </div>
            <div>
                <input type="number" id="category" placeholder="CategoryId">
            </div>
            <div>
                <input type="number" id="userId" placeholder="UserId">
            </div>
            <button id="createPost" >Create Post</button>
            `
        );
    } else {
        $(".create-post").empty();
        $(".create-post").append(
            `Please login to post a blog. <a href="../login/index.html">Login</a>`
        );
    }

    // creating new blog post
    $("#createPost").click(handleClickCreatePost);

    function handleClickCreatePost() {
        console.log('clicked create')
        let reqBody = {
            Title: $("#title").val(),
            Text: $("#postBody").val(),
            CategoryId: $("#category").val(),
            UserId: $("#userId").val()
        };
        console.log(reqBody)
        let headers = {
            'authorization': `Bearer ${jwt}`,
            'Access-Control-Allow-Origin': "*"
        }
        $.ajax({
            method: "POST",
            url: `${BASE_URL}/posts/create`,
            crossDomain: true,
            data: JSON.stringify(reqBody),
            contentType: "application/json",
            headers: headers,
            success: handleCreateSuccess,
            error: handleCreateError
        })

        function handleCreateSuccess(data) {
            console.log(data)
            
        }
        function handleCreateError(error) {
            console.log(error)
        }
    }

})