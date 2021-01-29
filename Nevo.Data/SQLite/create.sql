-- NUTRIENTS --
DROP TABLE IF EXISTS import_nutrients;
CREATE TABLE import_nutrients
(
    code    TEXT PRIMARY KEY,
    name_nl TEXT,
    unit    TEXT,
    name_en TEXT
);

.mode csv
.import --skip 1 nutrients.csv import_nutrients

DROP TABLE IF EXISTS import_nutritional_values;
CREATE TABLE import_nutritional_values
(
    group_code           INTEGER,
    group_description_nl TEXT,
    product_code         INTEGER PRIMARY KEY,
    description_nl       TEXT,
    description_en       TEXT,
    synonyms_nl          TEXT,
    unit                 TEXT,
    amount               INTEGER,
    comments_nl          TEXT,
    enriched_with        TEXT,
    trace_amounts        TEXT,
    ENERCJ_kJ            REAL,
    ENERCC_kcal          REAL,
    PROT_g               REAL,
    PROTPL_g             REAL,
    PROTAN_g             REAL,
    NT_g                 REAL,
    CHO_g                REAL,
    SUGAR_g              REAL,
    STARCH_g             REAL,
    POLYL_g              REAL,
    FIBT_g               REAL,
    ALC_g                REAL,
    WATER_g              REAL,
    OA_g                 REAL,
    FAT_g                REAL,
    FACID_g              REAL,
    FASAT_g              REAL,
    FAMSCIS_g            REAL,
    FAPU_g               REAL,
    FAPUN3_g             REAL,
    FAPUN6_g             REAL,
    FATRS_g              REAL,
    F4_0_g               REAL,
    F6_0_g               REAL,
    F8_0_g               REAL,
    F10_0_g              REAL,
    F11_0_g              REAL,
    F12_0_g              REAL,
    F13_0_g              REAL,
    F14_0_g              REAL,
    F15_0_g              REAL,
    F16_0_g              REAL,
    F17_0_g              REAL,
    F18_0_g              REAL,
    F19_0_g              REAL,
    F20_0_g              REAL,
    F21_0_g              REAL,
    F22_0_g              REAL,
    F23_0_g              REAL,
    F24_0_g              REAL,
    F25_0_g              REAL,
    F26_0_g              REAL,
    FASATXR_g            REAL,
    F10_1CIS_g           REAL,
    F12_1CIS_g           REAL,
    F14_1CIS_g           REAL,
    F16_1CIS_g           REAL,
    F18_1CIS_g           REAL,
    F20_1CIS_g           REAL,
    F22_1CIS_g           REAL,
    F24_1CIS_g           REAL,
    FAMSCXR_g            REAL,
    F18_2CN6_g           REAL,
    F18_2CN9_g           REAL,
    F18_2CT_g            REAL,
    F18_2TC_g            REAL,
    F18_2R_g             REAL,
    F18_3CN3_g           REAL,
    F18_3CN6_g           REAL,
    F18_4CN3_g           REAL,
    F20_2CN6_g           REAL,
    F20_3CN9_g           REAL,
    F20_3CN6_g           REAL,
    F20_3CN3_g           REAL,
    F20_4CN6_g           REAL,
    F20_4CN3_g           REAL,
    F20_5CN3_g           REAL,
    F21_5CN3_g           REAL,
    F22_2CN6_g           REAL,
    F22_2CN3_g           REAL,
    F22_3CN3_g           REAL,
    F22_4CN6_g           REAL,
    F22_5CN6_g           REAL,
    F22_5CN3_g           REAL,
    F22_6CN3_g           REAL,
    F24_2CN6_g           REAL,
    FAPUXR_g             REAL,
    F10_1TRS_g           REAL,
    F12_1TRS_g           REAL,
    F14_1TRS_g           REAL,
    F16_1TRS_g           REAL,
    F18_1TRS_g           REAL,
    F18_2TTN6_g          REAL,
    F18_3TTTN3_g         REAL,
    F20_1TRS_g           REAL,
    F20_2TT_g            REAL,
    F22_1TRS_g           REAL,
    F24_1TRS_g           REAL,
    FAMSTXR_g            REAL,
    FAUN_g               REAL,
    CHORL_mg             REAL,
    NA_mg                REAL,
    K_mg                 REAL,
    CA_mg                REAL,
    P_mg                 REAL,
    MG_mg                REAL,
    FE_mg                REAL,
    HAEM_mg              REAL,
    NHAEM_mg             REAL,
    CU_mg                REAL,
    SE_mug               REAL,
    ZN_mg                REAL,
    ID_mug               REAL,
    ASH_g                REAL,
    VITA_RAE_mug         REAL,
    VITA_RE_mug          REAL,
    RETOL_mug            REAL,
    CARTBTOT_mug         REAL,
    CARTA_mug            REAL,
    LUTN_mug             REAL,
    ZEA_mug              REAL,
    CRYPXB_mug           REAL,
    LYCPN_mug            REAL,
    VITD_mug             REAL,
    CHOCALOH_mug         REAL,
    CHOCAL_mug           REAL,
    VITE_mg              REAL,
    TOCPHA_mg            REAL,
    TOCPHB_mg            REAL,
    TOCPHG_mg            REAL,
    TOCPHD_mg            REAL,
    VITK_mug             REAL,
    VITK1_mug            REAL,
    VITK2_mug            REAL,
    THIA_mg              REAL,
    RIBF_mg              REAL,
    VITB6_mg             REAL,
    VITB12_mug           REAL,
    NIA_mg               REAL,
    FOL_mug              REAL,
    FOLFD_mug            REAL,
    FOLAC_mug            REAL,
    VITC_mg              REAL
);

.mode csv
.import --skip 1 nutrient_gehaltes.csv import_nutritional_values

DROP TABLE IF EXISTS import_nutritional_sources;
CREATE TABLE import_nutritional_sources
(
    group_code   INTEGER,
    product_code INTEGER,
    ENERCJ_kJ    TEXT,
    ENERCC_kcal  TEXT,
    PROT_g       TEXT,
    PROTPL_g     TEXT,
    PROTAN_g     TEXT,
    NT_g         TEXT,
    CHO_g        TEXT,
    SUGAR_g      TEXT,
    STARCH_g     TEXT,
    POLYL_g      TEXT,
    FIBT_g       TEXT,
    ALC_g        TEXT,
    WATER_g      TEXT,
    OA_g         TEXT,
    FAT_g        TEXT,
    FACID_g      TEXT,
    FASAT_g      TEXT,
    FAMSCIS_g    TEXT,
    FAPU_g       TEXT,
    FAPUN3_g     TEXT,
    FAPUN6_g     TEXT,
    FATRS_g      TEXT,
    F4_0_g       TEXT,
    F6_0_g       TEXT,
    F8_0_g       TEXT,
    F10_0_g      TEXT,
    F11_0_g      TEXT,
    F12_0_g      TEXT,
    F13_0_g      TEXT,
    F14_0_g      TEXT,
    F15_0_g      TEXT,
    F16_0_g      TEXT,
    F17_0_g      TEXT,
    F18_0_g      TEXT,
    F19_0_g      TEXT,
    F20_0_g      TEXT,
    F21_0_g      TEXT,
    F22_0_g      TEXT,
    F23_0_g      TEXT,
    F24_0_g      TEXT,
    F25_0_g      TEXT,
    F26_0_g      TEXT,
    FASATXR_g    TEXT,
    F10_1CIS_g   TEXT,
    F12_1CIS_g   TEXT,
    F14_1CIS_g   TEXT,
    F16_1CIS_g   TEXT,
    F18_1CIS_g   TEXT,
    F20_1CIS_g   TEXT,
    F22_1CIS_g   TEXT,
    F24_1CIS_g   TEXT,
    FAMSCXR_g    TEXT,
    F18_2CN6_g   TEXT,
    F18_2CN9_g   TEXT,
    F18_2CT_g    TEXT,
    F18_2TC_g    TEXT,
    F18_2R_g     TEXT,
    F18_3CN3_g   TEXT,
    F18_3CN6_g   TEXT,
    F18_4CN3_g   TEXT,
    F20_2CN6_g   TEXT,
    F20_3CN9_g   TEXT,
    F20_3CN6_g   TEXT,
    F20_3CN3_g   TEXT,
    F20_4CN6_g   TEXT,
    F20_4CN3_g   TEXT,
    F20_5CN3_g   TEXT,
    F21_5CN3_g   TEXT,
    F22_2CN6_g   TEXT,
    F22_2CN3_g   TEXT,
    F22_3CN3_g   TEXT,
    F22_4CN6_g   TEXT,
    F22_5CN6_g   TEXT,
    F22_5CN3_g   TEXT,
    F22_6CN3_g   TEXT,
    F24_2CN6_g   TEXT,
    FAPUXR_g     TEXT,
    F10_1TRS_g   TEXT,
    F12_1TRS_g   TEXT,
    F14_1TRS_g   TEXT,
    F16_1TRS_g   TEXT,
    F18_1TRS_g   TEXT,
    F18_2TTN6_g  TEXT,
    F18_3TTTN3_g TEXT,
    F20_1TRS_g   TEXT,
    F20_2TT_g    TEXT,
    F22_1TRS_g   TEXT,
    F24_1TRS_g   TEXT,
    FAMSTXR_g    TEXT,
    FAUN_g       TEXT,
    CHORL_mg     TEXT,
    NA_mg        TEXT,
    K_mg         TEXT,
    CA_mg        TEXT,
    P_mg         TEXT,
    MG_mg        TEXT,
    FE_mg        TEXT,
    HAEM_mg      TEXT,
    NHAEM_mg     TEXT,
    CU_mg        TEXT,
    SE_mug       TEXT,
    ZN_mg        TEXT,
    ID_mug       TEXT,
    ASH_g        TEXT,
    VITA_RAE_mug TEXT,
    VITA_RE_mug  TEXT,
    RETOL_mug    TEXT,
    CARTBTOT_mug TEXT,
    CARTA_mug    TEXT,
    LUTN_mug     TEXT,
    ZEA_mug      TEXT,
    CRYPXB_mug   TEXT,
    LYCPN_mug    TEXT,
    VITD_mug     TEXT,
    CHOCALOH_mug TEXT,
    CHOCAL_mug   TEXT,
    VITE_mg      TEXT,
    TOCPHA_mg    TEXT,
    TOCPHB_mg    TEXT,
    TOCPHG_mg    TEXT,
    TOCPHD_mg    TEXT,
    VITK_mug     TEXT,
    VITK1_mug    TEXT,
    VITK2_mug    TEXT,
    THIA_mg      TEXT,
    RIBF_mg      TEXT,
    VITB6_mg     TEXT,
    VITB12_mug   TEXT,
    NIA_mg       TEXT,
    FOL_mug      TEXT,
    FOLFD_mug    TEXT,
    FOLAC_mug    TEXT,
    VITC_mg      TEXT
);

.mode csv
.import --skip 1 nutrient_bronnen.csv import_nutritional_sources

DROP TABLE IF EXISTS import_sources;
CREATE TABLE import_sources
(
    source_id TEXT,
    source_nl TEXT
);

.mode csv
.import --skip 1 bronnen.csv import_sources

DROP TABLE IF EXISTS groups;
CREATE TABLE groups
(
    code           INTEGER PRIMARY KEY,
    description_en TEXT,
    description_nl TEXT
);

INSERT INTO groups (code, description_nl)
SELECT group_code, group_description_nl
FROM import_nutritional_values
GROUP BY group_code, group_description_nl;

DROP TABLE IF EXISTS products;
CREATE TABLE products
(
    code             INTEGER PRIMARY KEY,
    group_code       INTEGER,
    description_en   TEXT,
    description_nl   TEXT,
    synonyms_en      TEXT,
    synonyms_nl      TEXT,
    comments_en      TEXT,
    comments_nl      TEXT,
    enriched_with_en TEXT,
    enriched_with_nl TEXT,
    trace_amounts    TEXT,
    energy_kcal      REAL,
    energy_kj        REAL,
    FOREIGN KEY (group_code) REFERENCES groups (code)
);

INSERT INTO products(code,
                     group_code,
                     description_en,
                     description_nl,
                     synonyms_nl,
                     comments_nl,
                     enriched_with_nl,
                     trace_amounts,
                     energy_kcal,
                     energy_kj)
SELECT product_code,
       group_code,
       description_en,
       description_nl,
       synonyms_nl,
       comments_nl,
       enriched_with,
       trace_amounts,
       ENERCC_kcal,
       ENERCJ_kJ
FROM import_nutritional_values;

DROP TABLE IF EXISTS sources;
CREATE TABLE sources
(
    id        TEXT PRIMARY KEY,
    source_en TEXT,
    source_nl TEXT
);

INSERT INTO sources(id, source_nl)
SELECT source_id, source_nl
FROM import_sources;

DROP TABLE IF EXISTS nutrients;
CREATE TABLE nutrients
(
    code    TEXT PRIMARY KEY,
    name_en TEXT,
    name_nl TEXT
);

INSERT INTO nutrients(code, name_en, name_nl)
SELECT code, name_en, name_nl
FROM import_nutrients
WHERE code NOT IN ('ENERCJ', 'ENERCC');

DROP TABLE IF EXISTS product_nutrient;
CREATE TABLE product_nutrient
(
    product_code  INTEGER,
    nutrient_code TEXT,
    source_id     TEXT,
    percentage    REAL,
    FOREIGN KEY (product_code) REFERENCES products (code),
    FOREIGN KEY (nutrient_code) REFERENCES nutrients (code),
    FOREIGN KEY (source_id) REFERENCES sources (id)
);

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.PROT_g, CAST(NULLIF(replace(inv.PROT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'PROT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.PROTPL_g, CAST(NULLIF(replace(inv.PROTPL_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'PROTPL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.PROTAN_g, CAST(NULLIF(replace(inv.PROTAN_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'PROTAN';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.NT_g, CAST(NULLIF(replace(inv.NT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'NT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CHO_g, CAST(NULLIF(replace(inv.CHO_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CHO';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.SUGAR_g, CAST(NULLIF(replace(inv.SUGAR_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'SUGAR';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.STARCH_g, CAST(NULLIF(replace(inv.STARCH_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'STARCH';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.POLYL_g, CAST(NULLIF(replace(inv.POLYL_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'POLYL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FIBT_g, CAST(NULLIF(replace(inv.FIBT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FIBT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.ALC_g, CAST(NULLIF(replace(inv.ALC_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'ALC';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.WATER_g, CAST(NULLIF(replace(inv.WATER_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'WATER';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.OA_g, CAST(NULLIF(replace(inv.OA_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'OA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAT_g, CAST(NULLIF(replace(inv.FAT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FACID_g, CAST(NULLIF(replace(inv.FACID_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FACID';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FASAT_g, CAST(NULLIF(replace(inv.FASAT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FASAT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAMSCIS_g, CAST(NULLIF(replace(inv.FAMSCIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAMSCIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAPU_g, CAST(NULLIF(replace(inv.FAPU_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAPU';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAPUN3_g, CAST(NULLIF(replace(inv.FAPUN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAPUN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAPUN6_g, CAST(NULLIF(replace(inv.FAPUN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAPUN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FATRS_g, CAST(NULLIF(replace(inv.FATRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FATRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F4_0_g, CAST(NULLIF(replace(inv.F4_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F4:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F6_0_g, CAST(NULLIF(replace(inv.F6_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F6:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F8_0_g, CAST(NULLIF(replace(inv.F8_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F8:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F10_0_g, CAST(NULLIF(replace(inv.F10_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F10:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F11_0_g, CAST(NULLIF(replace(inv.F11_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F11:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F12_0_g, CAST(NULLIF(replace(inv.F12_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F12:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F13_0_g, CAST(NULLIF(replace(inv.F13_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F13:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F14_0_g, CAST(NULLIF(replace(inv.F14_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F14:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F15_0_g, CAST(NULLIF(replace(inv.F15_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F15:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F16_0_g, CAST(NULLIF(replace(inv.F16_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F16:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F17_0_g, CAST(NULLIF(replace(inv.F17_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F17:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_0_g, CAST(NULLIF(replace(inv.F18_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F19_0_g, CAST(NULLIF(replace(inv.F19_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F19:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_0_g, CAST(NULLIF(replace(inv.F20_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F21_0_g, CAST(NULLIF(replace(inv.F21_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F21:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_0_g, CAST(NULLIF(replace(inv.F22_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F23_0_g, CAST(NULLIF(replace(inv.F23_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F23:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F24_0_g, CAST(NULLIF(replace(inv.F24_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F24:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F25_0_g, CAST(NULLIF(replace(inv.F25_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F25:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F26_0_g, CAST(NULLIF(replace(inv.F26_0_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F26:0';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FASATXR_g, CAST(NULLIF(replace(inv.FASATXR_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FASATXR';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F10_1CIS_g, CAST(NULLIF(replace(inv.F10_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F10:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F12_1CIS_g, CAST(NULLIF(replace(inv.F12_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F12:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F14_1CIS_g, CAST(NULLIF(replace(inv.F14_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F14:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F16_1CIS_g, CAST(NULLIF(replace(inv.F16_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F16:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_1CIS_g, CAST(NULLIF(replace(inv.F18_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_1CIS_g, CAST(NULLIF(replace(inv.F20_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_1CIS_g, CAST(NULLIF(replace(inv.F22_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F24_1CIS_g, CAST(NULLIF(replace(inv.F24_1CIS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F24:1CIS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAMSCXR_g, CAST(NULLIF(replace(inv.FAMSCXR_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAMSCXR';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2CN6_g, CAST(NULLIF(replace(inv.F18_2CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2CN9_g, CAST(NULLIF(replace(inv.F18_2CN9_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2CN9';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2CT_g, CAST(NULLIF(replace(inv.F18_2CT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2CT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2TC_g, CAST(NULLIF(replace(inv.F18_2TC_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2TC';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2R_g, CAST(NULLIF(replace(inv.F18_2R_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2R';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_3CN3_g, CAST(NULLIF(replace(inv.F18_3CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:3CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_3CN6_g, CAST(NULLIF(replace(inv.F18_3CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:3CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_4CN3_g, CAST(NULLIF(replace(inv.F18_4CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:4CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_2CN6_g, CAST(NULLIF(replace(inv.F20_2CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:2CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_3CN9_g, CAST(NULLIF(replace(inv.F20_3CN9_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:3CN9';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_3CN6_g, CAST(NULLIF(replace(inv.F20_3CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:3CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_3CN3_g, CAST(NULLIF(replace(inv.F20_3CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:3CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_4CN6_g, CAST(NULLIF(replace(inv.F20_4CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:4CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_4CN3_g, CAST(NULLIF(replace(inv.F20_4CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:4CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_5CN3_g, CAST(NULLIF(replace(inv.F20_5CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:5CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F21_5CN3_g, CAST(NULLIF(replace(inv.F21_5CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F21:5CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_2CN6_g, CAST(NULLIF(replace(inv.F22_2CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:2CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_2CN3_g, CAST(NULLIF(replace(inv.F22_2CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:2CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_3CN3_g, CAST(NULLIF(replace(inv.F22_3CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:3CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_4CN6_g, CAST(NULLIF(replace(inv.F22_4CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:4CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_5CN6_g, CAST(NULLIF(replace(inv.F22_5CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:5CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_5CN3_g, CAST(NULLIF(replace(inv.F22_5CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:5CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_6CN3_g, CAST(NULLIF(replace(inv.F22_6CN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:6CN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F24_2CN6_g, CAST(NULLIF(replace(inv.F24_2CN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F24:2CN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAPUXR_g, CAST(NULLIF(replace(inv.FAPUXR_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAPUXR';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F10_1TRS_g, CAST(NULLIF(replace(inv.F10_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F10:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F12_1TRS_g, CAST(NULLIF(replace(inv.F12_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F12:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F14_1TRS_g, CAST(NULLIF(replace(inv.F14_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F14:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F16_1TRS_g, CAST(NULLIF(replace(inv.F16_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F16:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_1TRS_g, CAST(NULLIF(replace(inv.F18_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_2TTN6_g, CAST(NULLIF(replace(inv.F18_2TTN6_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:2TTN6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F18_3TTTN3_g, CAST(NULLIF(replace(inv.F18_3TTTN3_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F18:3TTTN3';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_1TRS_g, CAST(NULLIF(replace(inv.F20_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F20_2TT_g, CAST(NULLIF(replace(inv.F20_2TT_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F20:2TT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F22_1TRS_g, CAST(NULLIF(replace(inv.F22_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F22:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.F24_1TRS_g, CAST(NULLIF(replace(inv.F24_1TRS_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'F24:1TRS';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAMSTXR_g, CAST(NULLIF(replace(inv.FAMSTXR_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAMSTXR';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FAUN_g, CAST(NULLIF(replace(inv.FAUN_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FAUN';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CHORL_mg, CAST(NULLIF(replace(inv.CHORL_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CHORL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.NA_mg, CAST(NULLIF(replace(inv.NA_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'NA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.K_mg, CAST(NULLIF(replace(inv.K_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'K';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CA_mg, CAST(NULLIF(replace(inv.CA_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.P_mg, CAST(NULLIF(replace(inv.P_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'P';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.MG_mg, CAST(NULLIF(replace(inv.MG_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'MG';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FE_mg, CAST(NULLIF(replace(inv.FE_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FE';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.HAEM_mg, CAST(NULLIF(replace(inv.HAEM_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'HAEM';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.NHAEM_mg, CAST(NULLIF(replace(inv.NHAEM_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'NHAEM';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CU_mg, CAST(NULLIF(replace(inv.CU_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CU';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.SE_mug, CAST(NULLIF(replace(inv.SE_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'SE';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.ZN_mg, CAST(NULLIF(replace(inv.ZN_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'ZN';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.ID_mug, CAST(NULLIF(replace(inv.ID_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'ID';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.ASH_g, CAST(NULLIF(replace(inv.ASH_g, ',', '.'), '') AS REAL)
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'ASH';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITA_RAE_mug, CAST(NULLIF(replace(inv.VITA_RAE_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITA_RAE';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITA_RE_mug, CAST(NULLIF(replace(inv.VITA_RE_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITA_RE';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.RETOL_mug, CAST(NULLIF(replace(inv.RETOL_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'RETOL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CARTBTOT_mug, CAST(NULLIF(replace(inv.CARTBTOT_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CARTBTOT';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CARTA_mug, CAST(NULLIF(replace(inv.CARTA_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CARTA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.LUTN_mug, CAST(NULLIF(replace(inv.LUTN_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'LUTN';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.ZEA_mug, CAST(NULLIF(replace(inv.ZEA_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'ZEA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CRYPXB_mug, CAST(NULLIF(replace(inv.CRYPXB_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CRYPXB';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.LYCPN_mug, CAST(NULLIF(replace(inv.LYCPN_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'LYCPN';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITD_mug, CAST(NULLIF(replace(inv.VITD_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITD';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CHOCALOH_mug, CAST(NULLIF(replace(inv.CHOCALOH_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CHOCALOH';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.CHOCAL_mug, CAST(NULLIF(replace(inv.CHOCAL_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'CHOCAL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITE_mg, CAST(NULLIF(replace(inv.VITE_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITE';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.TOCPHA_mg, CAST(NULLIF(replace(inv.TOCPHA_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'TOCPHA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.TOCPHB_mg, CAST(NULLIF(replace(inv.TOCPHB_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'TOCPHB';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.TOCPHG_mg, CAST(NULLIF(replace(inv.TOCPHG_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'TOCPHG';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.TOCPHD_mg, CAST(NULLIF(replace(inv.TOCPHD_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'TOCPHD';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITK_mug, CAST(NULLIF(replace(inv.VITK_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITK';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITK1_mug, CAST(NULLIF(replace(inv.VITK1_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITK1';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITK2_mug, CAST(NULLIF(replace(inv.VITK2_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITK2';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.THIA_mg, CAST(NULLIF(replace(inv.THIA_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'THIA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.RIBF_mg, CAST(NULLIF(replace(inv.RIBF_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'RIBF';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITB6_mg, CAST(NULLIF(replace(inv.VITB6_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITB6';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITB12_mug, CAST(NULLIF(replace(inv.VITB12_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITB12';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.NIA_mg, CAST(NULLIF(replace(inv.NIA_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'NIA';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FOL_mug, CAST(NULLIF(replace(inv.FOL_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FOL';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FOLFD_mug, CAST(NULLIF(replace(inv.FOLFD_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FOLFD';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.FOLAC_mug, CAST(NULLIF(replace(inv.FOLAC_mug, ',', '.'), '') AS REAL) / 1000000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'FOLAC';

INSERT INTO product_nutrient
SELECT inv.product_code, innut.code, ins.VITC_mg, CAST(NULLIF(replace(inv.VITC_mg, ',', '.'), '') AS REAL) / 1000
FROM import_nutritional_values inv
         JOIN import_nutritional_sources ins on inv.product_code = ins.product_code
         JOIN import_nutrients innut ON innut.Code = 'VITC';

DELETE FROM product_nutrient WHERE percentage IS NULL;

UPDATE groups SET description_en = 'Potatoes and tubers'
WHERE description_en IS NULL AND code = '1';
UPDATE groups SET description_en = 'Alcoholic beverages'
WHERE description_en IS NULL AND code = '2';
UPDATE groups SET description_en = 'Bread'
WHERE description_en IS NULL AND code = '3';
UPDATE groups SET description_en = 'Miscellaneous foods'
WHERE description_en IS NULL AND code = '4';
UPDATE groups SET description_en = 'Eggs'
WHERE description_en IS NULL AND code = '5';
UPDATE groups SET description_en = 'Fruits'
WHERE description_en IS NULL AND code = '6';
UPDATE groups SET description_en = 'Pastry and biscuits'
WHERE description_en IS NULL AND code = '7';
UPDATE groups SET description_en = 'Cereals and cereal products'
WHERE description_en IS NULL AND code = '8';
UPDATE groups SET description_en = 'Vegetables'
WHERE description_en IS NULL AND code = '9';
UPDATE groups SET description_en = 'Savoury bread spreads'
WHERE description_en IS NULL AND code = '10';
UPDATE groups SET description_en = 'Savoury sauces'
WHERE description_en IS NULL AND code = '11';
UPDATE groups SET description_en = 'Savoury snacks'
WHERE description_en IS NULL AND code = '12';
UPDATE groups SET description_en = 'Cheese'
WHERE description_en IS NULL AND code = '13';
UPDATE groups SET description_en = 'Herbs and spices'
WHERE description_en IS NULL AND code = '14';
UPDATE groups SET description_en = 'Milk and milk products'
WHERE description_en IS NULL AND code = '15';
UPDATE groups SET description_en = 'Non‐alcoholic beverages'
WHERE description_en IS NULL AND code = '16';
UPDATE groups SET description_en = 'Nuts and seeds'
WHERE description_en IS NULL AND code = '17';
UPDATE groups SET description_en = 'Legumes'
WHERE description_en IS NULL AND code = '18';
UPDATE groups SET description_en = 'Foods for special nutritional use'
WHERE description_en IS NULL AND code = '19';
UPDATE groups SET description_en = 'Mixed dishes'
WHERE description_en IS NULL AND code = '20';
UPDATE groups SET description_en = 'Soups'
WHERE description_en IS NULL AND code = '21';
UPDATE groups SET description_en = 'Sugar, sweets and sweet sauces'
WHERE description_en IS NULL AND code = '22';
UPDATE groups SET description_en = 'Fats and oils'
WHERE description_en IS NULL AND code = '23';
UPDATE groups SET description_en = 'Fish'
WHERE description_en IS NULL AND code = '24';
UPDATE groups SET description_en = 'Meat and poultry'
WHERE description_en IS NULL AND code = '25';
UPDATE groups SET description_en = 'Meat substitutes and dairy substitutes'
WHERE description_en IS NULL AND code = '26';
UPDATE groups SET description_en = 'Cold meat cuts'
WHERE description_en IS NULL AND code = '27';

UPDATE products SET enriched_with_nl = NULL WHERE enriched_with_nl = '';
UPDATE products SET trace_amounts = NULL WHERE trace_amounts = '';
UPDATE products SET synonyms_nl = NULL WHERE synonyms_nl = '';
