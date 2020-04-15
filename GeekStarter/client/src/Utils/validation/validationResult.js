export class RuleValidationResult {
    constructor(isValid, message) {
        this.isValid = isValid;
        this.message = message;
    }
}

export class ValidationResult {
    constructor(isValid) {
        this.isValid = isValid;
    }

    addResult(field, ruleValidationResult) {
        this[field] = ruleValidationResult;
    }
}

