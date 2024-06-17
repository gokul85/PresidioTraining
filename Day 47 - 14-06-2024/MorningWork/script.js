function calculateAge(dob) {
    const birthDate = new Date(dob);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

function updateAge() {
    const dob = document.getElementById("dob").value;
    if (dob) {
        const age = calculateAge(dob);
        document.getElementById('age').value = age;
    }
}

function validateForm() {
    let errors = [];

    const name = document.getElementById('name').value;
    if (!name) {
        errors.push('Name is required.');
        document.getElementById('nameError').innerText = 'Name is required.';
    } else {
        document.getElementById('nameError').innerText = '';
    }

    const phone = document.getElementById('phone').value;
    const phoneRegex = /^\d{10}$/;
    if (!phone) {
        errors.push('Phone is required.');
        document.getElementById('phoneError').innerText = 'Phone is required.';
    } else if (!phoneRegex.test(phone)) {
        errors.push('Phone must be 10 digits.');
        document.getElementById('phoneError').innerText = 'Phone must be 10 digits.';
    } else {
        document.getElementById('phoneError').innerText = '';
    }

    const dob = document.getElementById('dob').value;
    if (!dob) {
        errors.push('Date of birth is required.');
        document.getElementById('dobError').innerText = 'Date of birth is required.';
    } else {
        document.getElementById('dobError').innerText = '';
    }

    const email = document.getElementById('email').value;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email) {
        errors.push('Email is required.');
        document.getElementById('emailError').innerText = 'Email is required.';
    } else if (!emailRegex.test(email)) {
        errors.push('Invalid email format.');
        document.getElementById('emailError').innerText = 'Invalid email format.';
    } else {
        document.getElementById('emailError').innerText = '';
    }

    const gender = document.querySelector('input[name="gender"]:checked');
    if (!gender) {
        errors.push('Gender is required.');
        document.getElementById('genderError').innerText = 'Gender is required.';
    } else {
        document.getElementById('genderError').innerText = '';
    }

    const qualification = document.querySelectorAll('input[name="qualification"]:checked');
    if (qualification.length === 0) {
        errors.push('At least one qualification is required.');
        document.getElementById('qualificationError').innerText = 'At least one qualification is required.';
    } else {
        document.getElementById('qualificationError').innerText = '';
    }

    const profession = document.getElementById('profession').value;
    if (!profession) {
        errors.push('Profession is required.');
        document.getElementById('professionError').innerText = 'Profession is required.';
    } else {
        if (!professionsArray.includes(profession)) {
            professionsArray.push(profession);
            loadProfessions();
        }
        document.getElementById('professionError').innerText = '';
    }

    if (errors.length > 0) {
        document.getElementById('submitError').innerText = errors.join('\n');
        document.getElementById('submitError').style.display = 'block';
    } else {
        document.getElementById('submitError').innerText = '';
        document.getElementById('submitError').style.display = 'none';
    }
}

document.querySelectorAll('input').forEach(input => {
    input.addEventListener('blur', function () {
        validateForm();
    });
});
