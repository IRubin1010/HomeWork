export default class ValidationRule {
    constructor(field, method, args, validWhen, message) {
        this.field = field;
        this.method = method;
        this.args = args;
        this.validWhen = validWhen;
        this.message = message;
    }
}