const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

let dom;
let document;

beforeAll((done) => {
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    dom.window.onload = () => {
        document = dom.window.document;
        done();
    };
});

function delay(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function waitForStatusMessage(expectedText, expectedClass) {
    return new Promise((resolve) => {
        const checkMessage = () => {
            const statusMessage = document.getElementById('status-message');
            if (statusMessage && statusMessage.textContent === expectedText && statusMessage.className.includes(expectedClass)) {
                resolve();
            } else {
                setTimeout(checkMessage, 10);
            }
        };
        checkMessage();
    });
}

test('should show success message on valid login', async () => {
    document.getElementById('username').value = 'user';
    document.getElementById('password').value = 'pass';
    document.getElementById('login-btn').click();

    await delay(100); // wait for the message to appear
    await waitForStatusMessage('Login successful!', 'success');

    const statusMessage = document.getElementById('status-message');
    expect(statusMessage).not.toBeNull();
    expect(statusMessage.textContent).toBe('Login successful!');
    expect(statusMessage.className).toContain('success');
});

test('should show error message on invalid login', async () => {
    document.getElementById('username').value = 'userr';
    document.getElementById('password').value = 'passs';
    document.getElementById('login-btn').click();

    await delay(100); // wait for the message to appear
    await waitForStatusMessage('Invalid username or password.', 'error');

    const statusMessage = document.getElementById('status-message');
    expect(statusMessage).not.toBeNull();
    expect(statusMessage.textContent).toBe('Invalid username or password.');
    expect(statusMessage.className).toContain('error');
});

test('should show error message when username or password is missing', async () => {
    document.getElementById('username').value = '';
    document.getElementById('password').value = 'pass';
    document.getElementById('login-btn').click();

    await delay(100); // wait for the message to appear
    await waitForStatusMessage('Please enter both username and password.', 'error');

    let statusMessage = document.getElementById('status-message');
    expect(statusMessage).not.toBeNull();
    expect(statusMessage.textContent).toBe('Please enter both username and password.');
    expect(statusMessage.className).toContain('error');

    document.getElementById('username').value = 'user';
    document.getElementById('password').value = '';
    document.getElementById('login-btn').click();

    await delay(100); // wait for the message to appear
    await waitForStatusMessage('Please enter both username and password.', 'error');

    statusMessage = document.getElementById('status-message');
    expect(statusMessage).not.toBeNull();
    expect(statusMessage.textContent).toBe('Please enter both username and password.');
    expect(statusMessage.className).toContain('error');
});
