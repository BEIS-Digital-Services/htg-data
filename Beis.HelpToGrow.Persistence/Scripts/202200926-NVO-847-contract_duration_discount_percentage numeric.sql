
-- Update contract_duration_discount_percentage data type
	ALTER TABLE public.product_price ALTER COLUMN contract_duration_discount_percentage TYPE numeric;
	ALTER TABLE public.product_price ALTER COLUMN contract_duration_discount_percentage SET DEFAULT 0.0;

-- Update Pembee contract_duration_discount_percentage
	UPDATE product_price pp 
	SET contract_duration_discount_percentage = 16.66
	WHERE contract_duration_discount_percentage = 17
	AND product_id  IN (
		SELECT product_id  FROM products WHERE product_name LIKE 'Pembee %'
	);