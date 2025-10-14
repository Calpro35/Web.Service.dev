-- INSERÇÃO DE DADOS

INSERT INTO TBL_SECTOR (NAME, CONSUMPTION_LIMIT) VALUES ('Setor de Produção', 1000.00);
INSERT INTO TBL_SECTOR (NAME, CONSUMPTION_LIMIT) VALUES ('Setor de Manutenção', 800.00);
INSERT INTO TBL_SECTOR (NAME, CONSUMPTION_LIMIT) VALUES ('Setor Administrativo', 500.00);
INSERT INTO TBL_SECTOR (NAME, CONSUMPTION_LIMIT) VALUES ('Setor de Pesquisa', 1200.00);


-- Equipamentos para o Setor 1
INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Esteira A1', 'A', 50.00, 5, SYSTIMESTAMP - 2/24, 1);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Prensa B2', 'I', 70.00, 4, NULL, 1);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Motor C3', 'A', 30.00, 6, SYSTIMESTAMP - 1/24, 1);

-- Equipamentos para o Setor 2
INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Ferramenta X1', 'I', 10.00, 8, NULL, 2);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Compressor Z3', 'A', 60.00, 3, SYSTIMESTAMP - 3/24, 2);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Maçarico Y7', 'I', 40.00, 4, NULL, 2);

-- Equipamentos para o Setor 3
INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Impressora Laser', 'A', 15.00, 6, SYSTIMESTAMP - 0.5, 3);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Scanner 3D', 'I', 20.00, 2, NULL, 3);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('PC Design', 'A', 25.00, 8, SYSTIMESTAMP - 1/48, 3);

-- Equipamentos para o Setor 4
INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Laboratório Químico', 'I', 90.00, 5, NULL, 4);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Microscópio Eletrônico', 'A', 45.00, 6, SYSTIMESTAMP - 4/24, 4);

INSERT INTO TBL_EQUIPMENT (name, status, consumption_per_hour, max_active_hours, last_activated_at, sector_id)
VALUES ('Incubadora Térmica', 'A', 35.00, 7, SYSTIMESTAMP - 6/24, 4);




-- Logs para equipamentos de ID entre 1 e 12
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 10, SYSTIMESTAMP - 9.5, 25.0, 1);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 9, SYSTIMESTAMP - 8.7, 30.5, 2);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 8, SYSTIMESTAMP - 7.8, 12.2, 3);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 7.5, SYSTIMESTAMP - 7.0, 45.0, 4);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 6.2, SYSTIMESTAMP - 6.0, 33.0, 5);

INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 6.0, SYSTIMESTAMP - 5.5, 41.7, 6);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 5.5, SYSTIMESTAMP - 5.3, 18.9, 7);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 5.0, SYSTIMESTAMP - 4.8, 50.0, 8);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 4.8, SYSTIMESTAMP - 4.4, 60.0, 9);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 4.5, SYSTIMESTAMP - 4.0, 72.5, 10);

INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 4.0, SYSTIMESTAMP - 3.7, 29.5, 11);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 3.5, SYSTIMESTAMP - 3.0, 37.0, 12);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 3.0, SYSTIMESTAMP - 2.7, 22.3, 1);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 2.7, SYSTIMESTAMP - 2.3, 55.0, 2);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 2.2, SYSTIMESTAMP - 2.0, 40.4, 3);

INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 2.0, SYSTIMESTAMP - 1.5, 60.0, 4);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 1.8, SYSTIMESTAMP - 1.4, 20.0, 5);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 1.3, SYSTIMESTAMP - 1.0, 45.9, 6);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 0.9, SYSTIMESTAMP - 0.6, 19.8, 7);
INSERT INTO TBL_EQUIPMENT_USAGE_LOG (started_at, ended_at, estimated_consumption, equipment_id) VALUES (SYSTIMESTAMP - 0.5, SYSTIMESTAMP - 0.1, 33.3, 8);








