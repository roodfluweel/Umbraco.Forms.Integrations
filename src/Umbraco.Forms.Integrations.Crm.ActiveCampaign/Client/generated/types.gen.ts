// This file is auto-generated by @hey-api/openapi-ts

export type AccountCollectionResponseDto = {
    accounts: Array<(AccountDto)>;
};

export type AccountDto = {
    id: string;
    name: string;
};

export type AllowedUploadType = {
    type: string;
    name: string;
    checked: string;
};

export type ApiAccessDto = {
    readonly account: string;
    readonly isApiConfigurationValid: boolean;
};

export type ContactFieldSettings = {
    name: string;
    displayName: string;
    required: boolean;
};

export type CustomFieldCollectionResponseDto = {
    fields: Array<(CustomFieldDto)>;
};

export type CustomFieldDto = {
    id: string;
    title: string;
};

export type Field = {
    caption: string;
    tooltip?: string | null;
    /**
     * @deprecated
     */
    placeholder?: string | null;
    cssClass?: string | null;
    alias: string;
    id: string;
    fieldTypeId: string;
    prevalueSourceId: string;
    dataSourceFieldKey?: string | null;
    containsSensitiveData: boolean;
    mandatory: boolean;
    regex?: string | null;
    requiredErrorMessage?: string | null;
    invalidErrorMessage?: string | null;
    condition?: FieldCondition | null;
    settings: {
        [key: string]: (string);
    };
    preValues: Array<(FieldPrevalue)>;
    allowedUploadTypes?: Array<(AllowedUploadType)> | null;
    allowMultipleFileUploads: boolean;
};

export type FieldCondition = {
    id: string;
    enabled: boolean;
    actionType: FieldConditionActionType;
    logicType: FieldConditionLogicType;
    rules: Array<(FieldConditionRule)>;
};

export enum FieldConditionActionType {
    SHOW = 'Show',
    HIDE = 'Hide'
}

export enum FieldConditionLogicType {
    ALL = 'All',
    ANY = 'Any'
}

export type FieldConditionRule = {
    id: string;
    field: string;
    operator: FieldConditionRuleOperator;
    value: string;
};

export enum FieldConditionRuleOperator {
    IS = 'Is',
    IS_NOT = 'IsNot',
    GREATER_THEN = 'GreaterThen',
    LESS_THEN = 'LessThen',
    CONTAINS = 'Contains',
    CONTAINS_IGNORE_CASE = 'ContainsIgnoreCase',
    STARTS_WITH = 'StartsWith',
    STARTS_WITH_IGNORE_CASE = 'StartsWithIgnoreCase',
    ENDS_WITH = 'EndsWith',
    ENDS_WITH_IGNORE_CASE = 'EndsWithIgnoreCase',
    NOT_CONTAINS = 'NotContains',
    NOT_CONTAINS_IGNORE_CASE = 'NotContainsIgnoreCase',
    NOT_STARTS_WITH = 'NotStartsWith',
    NOT_STARTS_WITH_IGNORE_CASE = 'NotStartsWithIgnoreCase',
    NOT_ENDS_WITH = 'NotEndsWith',
    NOT_ENDS_WITH_IGNORE_CASE = 'NotEndsWithIgnoreCase'
}

export type FieldPrevalue = {
    value: string;
    caption?: string | null;
};

export type GetAccountsResponse = AccountCollectionResponseDto;

export type GetFormFieldsData = {
    formId?: string;
};

export type GetFormFieldsResponse = Array<(Field)>;

export type CheckApiAccessResponse = ApiAccessDto;

export type GetCustomFieldsResponse = CustomFieldCollectionResponseDto;

export type GetContactFieldsResponse = Array<(ContactFieldSettings)>;

export type $OpenApiTs = {
    '/umbraco/activecampaign/management/api/v1/accounts': {
        get: {
            res: {
                /**
                 * OK
                 */
                200: AccountCollectionResponseDto;
            };
        };
    };
    '/umbraco/activecampaign/management/api/v1/forms/fields': {
        get: {
            req: GetFormFieldsData;
            res: {
                /**
                 * OK
                 */
                200: Array<(Field)>;
            };
        };
    };
    '/umbraco/activecampaign/management/api/v1/contacts/api-access': {
        get: {
            res: {
                /**
                 * OK
                 */
                200: ApiAccessDto;
            };
        };
    };
    '/umbraco/activecampaign/management/api/v1/contacts/custom': {
        get: {
            res: {
                /**
                 * OK
                 */
                200: CustomFieldCollectionResponseDto;
            };
        };
    };
    '/umbraco/activecampaign/management/api/v1/contacts/fields': {
        get: {
            res: {
                /**
                 * OK
                 */
                200: Array<(ContactFieldSettings)>;
            };
        };
    };
};