import {ValidationResult, RuleValidationResult} from './validationResult';

export default class FormValidator {

    constructor(validationRules) {
        this.validationRules = validationRules;
    }

    validate(state) {
        let validation = new ValidationResult(true);
        this.validationRules.forEach(rule => {
            if (state[rule.field] !== undefined && (!validation[rule.field] || validation[rule.field]?.isValid)) {
                const fieldValue = state[rule.field].toString();
                const args = rule.args || [];
                const validationMethod = rule.method;

                if(validationMethod(fieldValue, args, state) !== rule.validWhen) {
                    validation.addResult(rule.field, new RuleValidationResult(false, rule.message));
                    validation.isValid = false;
                }
            }
        });
        return validation;
    }
}