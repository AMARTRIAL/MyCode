///<copyrijght file='Contact.js'>
///Developed by AMAR
///</copyrijght>

if (typeof (ASB) === "undefined") { ASB = {}; }
if (typeof (ASB.Contact) === "undefined") {
    ASB.Contact = {
        OnLoad: function (ExecutionContext) {
        },

        OnChangeBirthday: function (ExecutionContext) {
            formContext = ExecutionContext.getFormContext();
            if (ASB.Helper.GetAttributeValue(formContext, 'asb_birthday') !== null && ASB.Helper.GetAttributeValue(formContext, 'asb_birthday') !== undefined) {
                var birthday = ASB.Helper.GetAttributeValue(formContext, 'asb_birthday')
                var today = new Date();
                today.setHours(0);
                today.setMinutes(0);
                today.setSeconds(0);
                birthday.setFullYear(today.getFullYear());
                ASB.Helper.SetAttributeValue(formContext, 'asb_upcommingbirthday', birthday);
            }
            else
            {
                ASB.Helper.SetAttributeValue(formContext, 'asb_upcommingbirthday', null);
            }
        },
    }
}