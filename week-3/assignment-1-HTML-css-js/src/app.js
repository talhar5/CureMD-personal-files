document.addEventListener('DOMContentLoaded', main, false);
function main() {
    // task - 1: To change color of nav items on mouse hover
    const navBtns = document.querySelectorAll('.main-navbar .nav-btn');
    navBtns.forEach(navItem => {
        navItem.addEventListener('mouseover', () => {
            navItem.style.color = 'black';
            navItem.style.backgroundColor = 'white';

        }, false)
        navItem.addEventListener('mouseout', () => {
            navItem.style.color = '';
            navItem.style.backgroundColor = '';

        }, false)
    })
 
    // task - 2: Switch images with buttons
    const imagesArr = [
        // more images can be added in this array
        '<img src="./src/images/img1.jpg" alt="Image">',
        '<img src="./src/images/img2.jpg" alt="Image">',
        '<img src="./src/images/img3.jpg" alt="Image">',
        '<img src="./src/images/img4.jpg" alt="Image">',
    ];
    const leftBtn = document.querySelector('.left-btn');
    const rightBtn = document.querySelector('.right-btn');
    const imgContainer = document.getElementById('img-container');
    leftBtn.addEventListener('click', handleClickLeft);
    rightBtn.addEventListener('click', handleClickRight);
    let index = 0; 
    imgContainer.innerHTML = imagesArr[index];
    function handleClickLeft() {
        index--;
        if (index < 0) index = imagesArr.length - 1;
        imgContainer.innerHTML = imagesArr[index];
    }
    function handleClickRight() {
        index++;
        if (index >= imagesArr.length) index = 0;
        imgContainer.innerHTML = imagesArr[index];
    }


    //===================================================================================
    // Interactive table
    const tableElem = document.querySelector('.menu-table');
    const btnsContainer = document.getElementById('btns-container');
    let tableRows = 4;
    addButton(btnsContainer);

    // functions
    function handleClickAddNew(){
        addEditRow(tableElem);
        document.getElementById('add-new-btn').remove();
        addSaveBtn(btnsContainer);
    }
    function handleClickSave(){
        let dishName = document.getElementById('dish-name').value;
        let serving = document.getElementById('serving').value;
        let price = document.getElementById('price').value;
        if(dishName == "" || serving == "" || price == "" ) return;
        addNewRow(tableElem, dishName, serving, price);
        document.getElementById('save-btn').remove();
        document.getElementById('cancel-btn').remove();
        document.getElementById('editing').remove();
        addButton(btnsContainer);
    }

    function handleClickCancel(){
        document.getElementById('save-btn').remove();
        document.getElementById('cancel-btn').remove();
        document.getElementById('editing').remove();
        addButton(btnsContainer);
    }


    function addSaveBtn(parentElem){
        // adding save button
        let saveBtn = document.createElement('button');
        saveBtn.innerText = "Save";
        saveBtn.classList.add('btn');
        saveBtn.onclick = handleClickSave;
        saveBtn.setAttribute('id', 'save-btn');
        parentElem.appendChild(saveBtn);
        // adding cancel button
        let cancelBtn = document.createElement('button');
        cancelBtn.innerText = "Cancel";
        cancelBtn.classList.add('btn');
        cancelBtn.onclick = handleClickCancel;
        cancelBtn.setAttribute('id', 'cancel-btn');
        parentElem.appendChild(cancelBtn);
        
    }
    function addButton(parentElem){
        let elem = document.createElement('button');
        elem.innerHTML = 'Add New...';
        elem.classList.add('btn');
        elem.setAttribute('id', 'add-new-btn');
        elem.onclick = handleClickAddNew;
        parentElem.appendChild(elem);
    }
    function addNewRow(parentElem ,dishName, serving, price){
        let elem = document.createElement('tr');
        elem.innerHTML = `
                        <td class="sr">${++tableRows}</td>
                        <td>${dishName}</td>
                        <td>${serving}</td>
                        <td>$${parseInt(price).toFixed(2)}</td>
                    `;
        parentElem.appendChild(elem);
    }
    function addEditRow(parentElem){
        let elem = document.createElement('tr');
        elem.innerHTML = `
                        <td>${tableRows + 1}</td>
                        <td><input type="text" id="dish-name" class="input-field" placeholder="Dish Name"></td>
                        <td><input type="number" id="serving" class="input-field" placeholder="Serving"></td>
                        <td><input type="number" id="price" class="input-field" placeholder="Price"></td>
                    `;
        elem.setAttribute('id', 'editing');
        parentElem.appendChild(elem);
    }

    //===================================================================================
    // form validations
    const nameElem = document.getElementById('name');
    const emailElem = document.getElementById('email');
    const commentElem = document.getElementById('comment');
    const errorName = document.querySelector('.name-error');
    const errorEmail = document.querySelector('.email-error');
    const errorComment = document.querySelector('.comment-error');
    
    // validate name
    let isNameTouched = false;
    nameElem.onblur = (e) => {
        isNameTouched = true;
        if(e.target.value === ""){
            errorName.style.visibility = 'visible';
        } else {
            errorName.style.visibility = 'hidden';
        }
    }
    nameElem.oninput = (e) => {
        console.log('fired');
        if(isNameTouched){
            if((e.target.value).length <= 3){
                errorName.style.visibility = 'visible';
            } else {
                errorName.style.visibility = 'hidden';
            }
        }
    }
    // validate email
    let isEmailTouched = false;
    emailElem.onblur = (e) => {
        isEmailTouched = true;
        if(e.target.value === ""){
            errorEmail.style.visibility = 'visible';
        } else {
            errorEmail.style.visibility = 'hidden';
        }
    }
    emailElem.oninput = (e) => {
        if(isEmailTouched){
            if((e.target.value).length <= 3){
                errorEmail.style.visibility = 'visible';
            } else {
                errorEmail.style.visibility = 'hidden';
            }
        }
    }
    // validate comment
    let isCommentTouched = false;
    commentElem.onblur = (e) => {
        isCommentTouched = true;
        if(countWords(e.target.value) < 5){
            errorComment.style.visibility = 'visible';
        } else {
            errorComment.style.visibility = 'hidden';
        }
    }
    commentElem.oninput = (e) => {
        if(isCommentTouched){
            if(countWords(e.target.value) < 5){
                errorComment.style.visibility = 'visible';
            } else {
                errorComment.style.visibility = 'hidden';
            }
        }
    }


    // function to count words in a string
    function countWords(str){
        if(str.length == 0) return 0;
        return str.trim().split(/\s+/).length;
    }
}   