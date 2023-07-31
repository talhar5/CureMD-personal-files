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
                <a href="./signup/index.html">
                    Sign Up
                </a>
            </li>
            <li>
                <a href="./login/index.html">
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




    $(".signout-btn").click(hanldeClickSignout);
    function hanldeClickSignout() {
        localStorage.setItem("jwt-token", "");
        localStorage.setItem("UserId", null);
        location.reload();
    }

    let posts = [];
    $(".posts-container").text("Fetching blog posts...");


    $.ajax({
        url: `${BASE_URL}/posts`,
        method: "GET",
        contentType: "application/json; charset=utf-8",
        success: handleGetSuccess,
        error: handleGetError
    });

    function handleGetSuccess(data) {
        posts = data;
        console.log(data)
        displayPosts();
    }
    function handleGetError(error) {

    }
    function displayPosts() {
        if (posts.length === 0) {
            $(".posts-container").empty();
            $(".posts-container").append(
                `No post has been posted yet, be the first one`
            );
            return;
        }
        $(".posts-container").empty();
        posts.forEach(item => {

            $(".posts-container").append(
                `
                    <div class="card" PostId=${item.Id}>
                        <h2>${item.Title}</h2>
                        <p>${item.Text}</p>
                        <p>Category: ${item.Category.Name}</p>
                        <p>Author: ${item.User.FirstName} ${item.User.LastName}</p>
                    </div>
                `
            );
        })

        $(".card").click((e)=>{
            console.log(e.currentTarget.getAttribute("PostId"))
        });
    }

    
});