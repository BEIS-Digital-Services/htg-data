﻿
	/*
	 * 1. New additional_cost.AdditionalCostDisplayValue Column
	 * 
	 */
	ALTER TABLE public.additional_cost
	ADD COLUMN IF NOT EXISTS additional_cost_display_value varchar(256) null;
	
	UPDATE public.additional_cost ac
	SET additional_cost_display_value = 
		CONCAT(REPLACE(CAST(CAST(ac."additionalCost" AS MONEY) AS varchar(256)), '$', '£'), ' ', LOWER(ac.additional_cost_freq)) 
	WHERE 	
			additional_cost_display_value IS NULL 	
		AND ac."additionalCost" IS NOT NULL 
		AND ac.additional_cost_freq IS NOT NULL;
		

	/*
	 * 2. New AdditionalCostType Table
	 * 
	 */
	ALTER TABLE public.additional_cost DROP CONSTRAINT IF EXISTS "FK_additional_cost_additional_cost_type_additional_cost_type_id";
	ALTER TABLE public.additional_cost DROP COLUMN IF EXISTS additional_cost_type_id;
	
	DROP TABLE IF EXISTS public.additional_cost_type;
	CREATE TABLE public.additional_cost_type (
		additional_cost_type_id INT8 NOT NULL GENERATED ALWAYS AS IDENTITY,
		description VARCHAR(256) NOT NULL,
		CONSTRAINT "PK_TransactionFeeDescription" PRIMARY KEY (additional_cost_type_id)
	);
	
	INSERT INTO public.additional_cost_type (description) 
	VALUES 
	('General'),
	('TransactionFee'),
	('ThirdPartyFee');
	
	
	ALTER TABLE public.additional_cost ADD COLUMN IF NOT EXISTS additional_cost_type_id INT8 NOT NULL DEFAULT 1;
	ALTER TABLE public.additional_cost ADD CONSTRAINT "FK_additional_cost_additional_cost_type_additional_cost_type_id" 
		FOREIGN KEY (additional_cost_type_id) REFERENCES public.additional_cost_type(additional_cost_type_id) ON DELETE RESTRICT;
	
	
	/* 
	 * 	Slightly convoluted way of inserting new additional_cost_desc rows.
	 * 	Ensures a) no duplicates and b) resolves an issue with the seed of autogenerated ids, issue existed in DEV, possibly also UAT/PROD.
	 */ 
	DROP PROCEDURE IF EXISTS tmp_insert_additional_cost_desc_data;
	CREATE PROCEDURE tmp_insert_additional_cost_desc_data(costDescParam varchar(256))
	LANGUAGE SQL
	AS $$	
		WITH insert_values AS (
			SELECT MAX(additional_cost_desc_id) + 1  AS NewPK -- Some seed issue with the generated ids, plain insert fails
			FROM public.additional_cost_desc  
		)
		INSERT INTO public.additional_cost_desc (additional_cost_desc_id, "additional_costDesc", additional_cost_desc)
		SELECT insert_values.NewPK, costDescParam, NULL FROM insert_values
		WHERE NOT EXISTS (SELECT 1 FROM public.additional_cost_desc WHERE "additional_costDesc" = costDescParam);
	$$;
	
	-- INSERT Transaction Fees:
	CALL tmp_insert_additional_cost_desc_data('Transaction fee defined by max number of sales transactions');
	CALL tmp_insert_additional_cost_desc_data('Transaction fee defined by tiered number of sales transactions');
	CALL tmp_insert_additional_cost_desc_data('Transaction fee defined by max total sales £');
	CALL tmp_insert_additional_cost_desc_data('Transaction fee defined by tiered total sales £');
	CALL tmp_insert_additional_cost_desc_data('Transaction fee as % of sale');
	CALL tmp_insert_additional_cost_desc_data('Transaction flat fee');
	CALL tmp_insert_additional_cost_desc_data('Charge for non-integrated card payments systems');
	-- INSERT Third-party payment fees:
	CALL tmp_insert_additional_cost_desc_data('Payment fees');
		
	DROP PROCEDURE IF EXISTS tmp_insert_additional_cost_desc_data;
	

