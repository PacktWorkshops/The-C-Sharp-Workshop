--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 13.2

-- Started on 2021-04-08 06:02:03

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 29137)
-- Name: factory; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA factory;


ALTER SCHEMA factory OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 201 (class 1259 OID 29138)
-- Name: product; Type: TABLE; Schema: factory; Owner: postgres
--

CREATE TABLE factory.product (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    price money NOT NULL,
    manufacturerid integer NOT NULL
);


ALTER TABLE factory.product OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 29141)
-- Name: Product_Id_seq; Type: SEQUENCE; Schema: factory; Owner: postgres
--

ALTER TABLE factory.product ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME factory."Product_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 203 (class 1259 OID 37330)
-- Name: manufacturer; Type: TABLE; Schema: factory; Owner: postgres
--

CREATE TABLE factory.manufacturer (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    country character varying(50) NOT NULL
);


ALTER TABLE factory.manufacturer OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 37333)
-- Name: manufacturer_id_seq; Type: SEQUENCE; Schema: factory; Owner: postgres
--

ALTER TABLE factory.manufacturer ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME factory.manufacturer_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2994 (class 0 OID 37330)
-- Dependencies: 203
-- Data for Name: manufacturer; Type: TABLE DATA; Schema: factory; Owner: postgres
--

COPY factory.manufacturer (id, name, country) FROM stdin;
1	Belgium Toys	Belgium
17	Best Buy	USA
18	Iron Retail	USA
\.


--
-- TOC entry 2992 (class 0 OID 29138)
-- Dependencies: 201
-- Data for Name: product; Type: TABLE DATA; Schema: factory; Owner: postgres
--

COPY factory.product (id, name, price, manufacturerid) FROM stdin;
2	Firefighter Truck	10,49 €	1
1	Toy Car	1,60 €	1
12	Loli microphone	5,00 €	18
\.


--
-- TOC entry 3001 (class 0 OID 0)
-- Dependencies: 202
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: factory; Owner: postgres
--

SELECT pg_catalog.setval('factory."Product_Id_seq"', 20013, true);


--
-- TOC entry 3002 (class 0 OID 0)
-- Dependencies: 204
-- Name: manufacturer_id_seq; Type: SEQUENCE SET; Schema: factory; Owner: postgres
--

SELECT pg_catalog.setval('factory.manufacturer_id_seq', 20, true);


--
-- TOC entry 2860 (class 2606 OID 37339)
-- Name: manufacturer manufacturer_pkey; Type: CONSTRAINT; Schema: factory; Owner: postgres
--

ALTER TABLE ONLY factory.manufacturer
    ADD CONSTRAINT manufacturer_pkey PRIMARY KEY (id);


--
-- TOC entry 2858 (class 2606 OID 37329)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: factory; Owner: postgres
--

ALTER TABLE ONLY factory.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- TOC entry 2861 (class 2606 OID 37345)
-- Name: product product_manufacturerid_id; Type: FK CONSTRAINT; Schema: factory; Owner: postgres
--

ALTER TABLE ONLY factory.product
    ADD CONSTRAINT product_manufacturerid_id FOREIGN KEY (manufacturerid) REFERENCES factory.manufacturer(id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


-- Completed on 2021-04-08 06:02:03

--
-- PostgreSQL database dump complete
--

