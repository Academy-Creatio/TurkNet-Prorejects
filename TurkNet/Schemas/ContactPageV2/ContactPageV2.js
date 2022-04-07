define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		attributes: {
			

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
				this.showInformationDialog("Email has changed to: "+this.$Email);
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
