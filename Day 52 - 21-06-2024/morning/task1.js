let user = {
    name: "Alex",
    surname: "",

    set fullName(value) {
        [this.name, this.surname] = value.split(" ");
    },

    get fullName() {
        return `${this.name} ${this.surname}`;
    }
};

let admin = {
    isAdmin: true
};

admin.__proto__ = user;

console.log(admin.fullName);


admin.fullName = "Alice ";

console.log(admin.fullName);
console.log(user.fullName);