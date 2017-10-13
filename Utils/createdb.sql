CREATE TABLE IF NOT EXISTS cities
(
  id serial PRIMARY KEY,
  name text NOT NULL
);

CREATE TABLE IF NOT EXISTS roads
(
  id serial  PRIMARY KEY,
  city_from integer NOT NULL,
  city_to integer  NOT NULL,
  distance integer NOT NULL
);

DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'roads_city_from_fkey') THEN
        ALTER TABLE roads
        ADD CONSTRAINT roads_city_from_fkey FOREIGN KEY (city_from)
        REFERENCES cities (id) MATCH SIMPLE
        ON UPDATE NO ACTION ON DELETE NO ACTION;
    END IF;
END;
$$;

DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'roads_city_to_fkey') THEN
        ALTER TABLE roads
        ADD CONSTRAINT roads_city_to_fkey FOREIGN KEY (city_to)
        REFERENCES cities (id) MATCH SIMPLE
        ON UPDATE NO ACTION ON DELETE NO ACTION;
    END IF;
END;
$$;
