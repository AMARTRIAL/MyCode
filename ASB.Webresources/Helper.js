///<copyrijght file='Helper.js'>
///Developed by AMAR
///</copyrijght>
if (typeof (ASB) === "undefined") { ASB = {}; }
if (typeof (ASB.Helper) === "undefined") {
    ASB.Helper = {
        GetAttributeValue: function (formContext, fieldName) {
            return formContext.getAttribute(fieldName).getValue();
        },

        SetAttributeValue: function (formContext, fieldName, value) {
            formContext.getAttribute(fieldName).setValue(value);
        },

        GetLookupValue: function (formContext, fieldName) {
            return formContext.getAttribute(fieldName).getValue()[0];
        },

        EnableDisableAttribute: function (formCotext, fieldName, value) {
            if (formCotext.getControl(fieldName)) {
                formContext.getControl(fieldName).setDisable(value);
            }
        },

        EnableDisableAllControls: function (formCotext, fieldName, value) {
            //if a control used multiple time in form.
            if (formCotext.getAttribute(fieldName)) {
                if (formCotext.getAttribute(fieldName).controls._keys.length > 1) {
                    formCotext.getAttribute(fieldName).getControls.forEach(
                        function (control) {
                            control.setDisable(value);
                        }
                    )
                }
            }
        },

        EnableDisableAllAttribute: function (formContext, isDisable) {
            formContext.ui.controls.forEach(function (control, i) {
                if (control && control.getDisabled && !control.getDisabled()) {
                    control.setDisable(isDisable);
                }
            });
        },

        OpenForm: function (entityFormOptions) {
            ///entityFormOptions example
            ///entityFormOptions["entityName"] = 'lead';
            ///entityFormOptions["entityId"] = '32 digit guid';
            Xrm.Navigation.openForm().then(
                function (success) {
                    console.log(success);
                },
                function (error) {
                    console.log(error);
                }
            );
        },

        LookupPreSearch: function (formContext, toBeFilteredControl,FilteredByControl) {
            if (formContext.getControl(toBeFilteredControl) !== null && formContext.getControl(toBeFilteredControl) !== undefined) {
                //Presearch event
                formContext.getControl(toBeFilteredControl).addPresearch(ASB.Helper.addFilterQuery)

            }
        },

        addFilterQuery: function (formContext, FilteredByControl) {
            var query;
            try {
                var lookupId = formContext.getAttribute(FilteredByControl).getValue()[0].id;
                query = "<filter type='and'><condition attribute='" + FilteredByControl + "' operator ='eq' value = '" + lookupId+"' /></filter>";
            }
            catch (e)
            {
                console.log("Error : "+ e);
            }
        },

        IsDirty: function (formContext, fieldName) {
            var isDir;
            var control = formContext.getAttribute(fieldName);
            if (control !== null) {
                isDir = control.getIsDirty();
            }
            return isDir;
        },
    }
}