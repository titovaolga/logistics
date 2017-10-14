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


CREATE TABLE IF NOT EXISTS cartypes
(
  id serial PRIMARY KEY,
  cargo_type text NOT NULL,
  cost_empty double precision NOT NULL CHECK (cost_empty > 0),
  cost_full double precision NOT NULL CHECK (cost_full > 0),
  cost_stand double precision NOT NULL,
  payload real NOT NULL CHECK (payload > 0)
);


CREATE TABLE IF NOT EXISTS cars
(
  id serial NOT NULL PRIMARY KEY,
  "number" text NOT NULL UNIQUE,
  cost double precision NOT NULL CHECK (cost > 0),
  cartype_id integer NOT NULL
);


CREATE TABLE IF NOT EXISTS transactions
(
  id serial NOT NULL PRIMARY KEY,
  car_id integer NOT NULL,
  is_full boolean NOT NULL,
  city_from integer NOT NULL,
  city_to integer NOT NULL,
  date_from date NOT NULL,
  date_to date NOT NULL
);

