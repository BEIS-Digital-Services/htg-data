ALTER TABLE public.product_price
ADD COLUMN IF NOT EXISTS product_price_currency char(3) NOT NULL DEFAULT 'GBP';