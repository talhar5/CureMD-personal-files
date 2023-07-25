$(document).ready(() => {
    const POSTS_API = 'https://jsonplaceholder.typicode.com/posts';

    let posts = [];
    let startIndex = 0;
    let totalPosts = 0;
    // next button functionality
    $('.next-btn').click(() => {
        startIndex += 10;
        refreshBtns();
        displayLoader();
        fetchPosts();
    });
    // previous button functionality
    $('.prev-btn').click(() => {
        startIndex -= 10;
        refreshBtns();
        displayLoader();
        fetchPosts();
    });


    // fetch and display posts for the first time
    displayLoader();
    fetchPosts();
    // updateStats();


    // function to render posts available in the array posts[]
    function displayPosts() {
        updateStats();
        $('.spinner').css('display', 'none');
        $('.posts-container').empty();
        for (let i = startIndex; i < startIndex + 10 && i < totalPosts; i++) {
            $('.posts-container').append(makePost(posts[i]));
        }


    }
    // function to make a post
    function makePost(post) {
        return `
                <div class="post">
                    <h2>${post.title}</h2>
                    <p>${post.body}</p>
                </div>
                `;
    }
    function displayLoader() {
        $('.posts-container').empty();
        $('.spinner').css('display', 'block');
    }
    function displayError(error) {
        console.log('Some error has occured');
        $('.spinner').css('display', 'none');
        $('.posts-container').html(
            '<div class="error">Some Error has occured!</div>'
        );
    }
    function fetchPosts() {
        $.ajax({
            method: 'GET',
            url: POSTS_API,
            success: (data) => {
                posts = data;
                totalPosts = data.length;
                refreshBtns();
                displayPosts();
            },
            error: displayError,

        })
    }
    function refreshBtns() {
        if (startIndex <= 9) {
            $('.prev-btn').attr('disabled', 'true');
        } else {
            $('.prev-btn').removeAttr('disabled');
        }
        if (startIndex >= totalPosts - 10) {
            $('.next-btn').attr('disabled', 'true');
        } else {
            $('.next-btn').removeAttr('disabled');
        }
    }
    function updateStats(){
        $('.stats').text(
            `Showing ${startIndex + 1}-${startIndex + 10} posts out of ${totalPosts} posts`
        );
    }
});