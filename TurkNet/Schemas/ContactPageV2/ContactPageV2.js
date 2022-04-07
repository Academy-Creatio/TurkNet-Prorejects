define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		attributes: {

			"Account": {
				lookupListConfig: {
					columns: ["Web", "Owner", "Type"]
				}
			},
			 "MyEvents": {
				dependencies: [
					{
						columns: ["Name"],
						methodName: "onNameChanged"
					},
					{
						columns: ["Email"],
						methodName: "onEmailChanged"
					}
				]
			},
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {

			/**
			* @inheritdoc Terrasoft.BasePageV2#init
			*/
			init: function() {
				this.callParent(arguments);
			},

			/**
			* @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			*/
			onEntityInitialized: function() {
				this.callParent(arguments);
			},

			onNameChanged: function(){
				this.showInformationDialog("Name has changed to: "+this.$Name);
			},
			onEmailChanged: function(){
				//this.showInformationDialog("Email has changed to: "+this.$Email);
			},
			
			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			 setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Email", this.emailValidator);
				this.addColumnValidator("Name", this.nameValidator);
			 },

			 emailValidator: function(){
				var invalidMessage = "";
				
				let emailDomain = this.$Email.split('@')[1];
				let accountDomain = this.$Account.Web;
				if(emailDomain !== accountDomain){
					invalidMessage = "Domains dont match";
				}else{
					invalidMessage = "";
				}
				
				return {
					invalidMessage: invalidMessage
				};
			 },
			 nameValidator: function(){
				var invalidMessage = "";
				
				let name= this.$Name;
				if(name.includes("Supervisor")|| name.includes("Kirill")){
					invalidMessage = "NO !!!!!!!";
				}else{
					invalidMessage = "";
				}
				
				return {
					invalidMessage: invalidMessage
				};
			 }



		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MyEmail",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "ContactGeneralInfoBlock"
					},
					"bindTo": "Email"
				},
				"parentName": "ContactGeneralInfoBlock",
				"propertyName": "items",
				"index": 6
			}
		]/**SCHEMA_DIFF*/
	};
});
