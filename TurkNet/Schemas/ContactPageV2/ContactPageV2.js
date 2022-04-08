define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		messages:{
			/**
			 * Published on: ContactSectionV2
			 * @tutorial https://academy.creatio.com/docs/developer/front-end_development/sandbox_component/module_message_exchange
			 */
			"SectionActionClicked":{
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
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
			//#region PAGE LIFECYCLE
			/**
			* @inheritdoc Terrasoft.BasePageV2#init
			*/
			init: function() {
				this.callParent(arguments);
				this.subscribeToMessages();
			},
			/**
			* @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			*/
			onEntityInitialized: function() {
				this.callParent(arguments);
			},
			//#endregion

			//#region MESSAGES
			subscribeToMessages: function(){
				this.sandbox.subscribe(
					"SectionActionClicked",
					function(args){this.onSectionMessageReceived(args);},
					this,
					[this.sandbox.id]
				)
			},
			onSectionMessageReceived: function(args){
				let arg1 = args.arg1;
				let arg2 = args.arg2;
				this.showInformationDialog("Message received with arguments+: arg1: "+arg1+" arg2: "+arg2);
			},
			//#endregion

			//#region EVENTS-ATTRIBUTES
			onNameChanged: function(){
				this.showInformationDialog("Name has changed to: "+this.$Name);
			},
			onEmailChanged: function(){
				//this.showInformationDialog("Email has changed to: "+this.$Email);
			},
			//#endregion

			//#region VALIDATION
			
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
			 },
			//#endregion

			//#region ACTIONS
			/**
			 * @inheritdoc Terrasoft.BasePageV2#getActions
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuSeparator());
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "tag1",
					//"Caption": {"bindTo": "Resources.Strings.ActionItemOne"},
					"Caption":  this.get("Resources.Strings.ActionItemOne"),
					"Click": {"bindTo": "onActionItemClicked"},
					ImageConfig: this.get("Resources.Images.CreatioSquare")
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "tag2",
					"Caption": this.get("Resources.Strings.ActionItemTwo"),
					"Click": {"bindTo": "onActionItemClicked"},
					Items: this.addSubItems(),
					ImageConfig: this.get("Resources.Images.CreatioSquare")
				}));
				return actionMenuItems;
			},
			addSubItems: function(){
				var collection = this.Ext.create("Terrasoft.BaseViewModelCollection");
				collection.addItem(this.getButtonMenuItem({
					"Caption": this.get("Resources.Strings.SubActionOneCaption"),
					"Click": {"bindTo": "onSubActionOneClick"},
					"Tag": "sub1"
				}));
				collection.addItem(this.getButtonMenuItem({
					"Caption": this.get("Resources.Strings.SubActionTwoCaption"),
					"Click": {"bindTo": "onSubActionTwoClick"},
					"Tag": "sub2"
				}));
				return collection;
			},
			onActionItemClicked: function(){
				let tag = arguments[0];
				this.showInformationDialog("onActionItemClicked");
			},
			onSubActionOneClick: function(){
				let tag = arguments[0];
				this.showInformationDialog("onSubActionOneClick");
			},
			onSubActionTwoClick: function(){
				let tag = arguments[0];
				this.showInformationDialog("onSubActionTwoClick");
			},
			//#endregion
			
			//#region BUTTON HANDLERS
			
			/**
			 * Handles MyRedButton click
			 */
			 onMyRedButtonClick: function(){
				let tag = arguments[3];
				this.showInformationDialog("MyRedButton Clicked, tag is: "+tag);
			}
			//#endregion
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
			},
			{
				"operation": "insert",
				"name": "MyRedButton",
				"values": {
					"itemType": 5,
					"style": "red",
					"classes": {
						"textClass": [
							"actions-button-margin-right"
						],
						"wrapperClass": [
							"actions-button-margin-right"
						]
					},
					"caption": "Red button",
					"hint": "Page red button hint",
					"click": {
						"bindTo": "onMyRedButtonClick"
					},
					"tag": "LeftContainer_Red"
				},
				"parentName": "LeftContainer",
				"propertyName": "items",
				"index": 7
			},
		]/**SCHEMA_DIFF*/
	};
});
