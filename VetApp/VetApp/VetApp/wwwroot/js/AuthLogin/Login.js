const nickname = document.getElementById('nickname');
const password = document.getElementById('password');
const loginButton = document.getElementById('loginbtn');


function validateFields() {
    const nameN = nickname.value.trim();
    const passwordN = password.value.trim();

    
    if (nameN !== '' && passwordN !== '') {
        loginButton.disabled = false; 
    } else {
        loginButton.disabled = true; 
    }
}

nickname.addEventListener('input', validateFields);
password.addEventListener('input', validateFields);

validateFields(); 