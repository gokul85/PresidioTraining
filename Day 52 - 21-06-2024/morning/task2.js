class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    greet() {
        console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
    }
}

class Student extends Person {
    constructor(name, age, studentId) {
        super(name, age);
        this.studentId = studentId;
        this._grades = [];
    }

    get grades() {
        return this._grades;
    }

    set grades(newGrade) {
        this._grades.push(newGrade);
    }

    study() {
        console.log(`${this.name} is studying.`);
    }

    // Overriding
    greet() {
        console.log(`Hello, my name is ${this.name}, I am ${this.age} years old, and my student ID is ${this.studentId}.`);
    }
}

let student1 = new Student('John', 21, 'S1');
student1.greet();
student1.study();
student1.grades = 90;
student1.grades = 100;
console.log(student1.grades);
