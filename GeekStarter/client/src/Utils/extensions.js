String.prototype.capitalize = function() {
    return this.charAt(0).toUpperCase() + this.slice(1);
};

String.prototype.initials = function() {
    return this.match(/\b(\w)/g).join('').toUpperCase();
};