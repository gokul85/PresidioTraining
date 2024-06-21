document.addEventListener('DOMContentLoaded', () => {
    function showStatusMessage(message, type) {
        const statusMessage = document.getElementById('status-message');
        statusMessage.textContent = message;
        statusMessage.className = type;

        setTimeout(() => {
            statusMessage.textContent = '';
            statusMessage.className = '';
        }, 3000);
    }

    const users = [
        { username: "user", password: "pass" },
        { username: "admin", password: "adminpass" }
    ];

    document.getElementById('login-btn').addEventListener('click', function () {
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;

        if (!username || !password) {
            showStatusMessage('Please enter both username and password.', 'error');
            return;
        }

        const user = users.find(user => user.username === username && user.password === password);
        if (user) {
            showStatusMessage('Login successful!', 'success');
        } else {
            showStatusMessage('Invalid username or password.', 'error');
        }
    });
});
