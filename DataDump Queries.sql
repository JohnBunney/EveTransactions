SELECT * FROM invItems

SELECT * FROM invNames

SELECT * FROM invTypes
WHERE 
typeID = 363359
typeName = 'Gnosis'

SELECT 
typeID
,typeName
--,ISNULL(parent2.marketGroupName, parent.marketGroupName) AS parentGroup2 
,ISNULL(parent3.marketGroupName, ISNULL(parent2.marketGroupName, parent.marketGroupName)) AS baseGroup 
,parent3.marketGroupName AS baseGroup
,parent3.marketGroupID AS baseGroupid 
,parent2.marketGroupName AS subGroup 
,parent2.marketGroupID AS subGroupid 
,parent.marketGroupName AS itemGroup 
,parent.marketGroupID itemGroupid 
,invMarketGroups.marketGroupName AS whtgroup 
--,* 
FROM invTypes
LEFT JOIN invMarketGroups ON invTypes.marketGroupID = invMarketGroups.marketGroupID
LEFT OUTER JOIN invMarketGroups parent ON invMarketGroups.parentGroupID = parent.marketGroupID
LEFT OUTER JOIN invMarketGroups parent2 ON parent.parentGroupID = parent2.marketGroupID
LEFT OUTER JOIN invMarketGroups parent3 ON parent2.parentGroupID = parent3.marketGroupID
WHERE 
    invTypes.marketGroupID IS NOT NULL 
AND (invTypes.marketGroupID NOT IN (350001, 353580, 1041, 477, 2, 475, 1396, 353567, 353592, 353565, 1659))
AND (parent3.marketGroupID IS NULL OR parent3.marketGroupID NOT IN (350001, 353580, 1041, 477, 2, 475, 1396, 353567, 353592, 353565, 1659))
AND (parent2.marketGroupID IS NULL OR parent2.marketGroupID NOT IN (350001, 353580, 1041, 477, 2, 475, 1396, 353567, 353592, 353565, 1659))
AND (parent.marketGroupID IS NULL OR parent.marketGroupID NOT IN (350001, 353580, 1041, 477, 2, 475, 1396, 353567, 353592, 353565, 1659))
--AND parent3.marketGroupName = 'Ships'
AND typeName like '%Blue%'
ORDER BY invTypes.typeID


-- Excluded
SELECT typeID, typeName, invMarketGroups.marketGroupName, 
parent.marketGroupName AS parentGroup, 
ISNULL(parent2.marketGroupName, parent.marketGroupName) AS parentGroup2, 
ISNULL(parent3.marketGroupName, ISNULL(parent2.marketGroupName, parent.marketGroupName)) AS parentGroup3, 
parent3.marketGroupID AS parentGroup3id, 
parent.marketGroupID, * FROM invTypes
LEFT JOIN invMarketGroups ON invTypes.marketGroupID = invMarketGroups.marketGroupID
LEFT OUTER JOIN invMarketGroups parent ON invMarketGroups.parentGroupID = parent.marketGroupID
LEFT OUTER JOIN invMarketGroups parent2 ON parent.parentGroupID = parent2.marketGroupID
LEFT OUTER JOIN invMarketGroups parent3 ON parent2.parentGroupID = parent3.marketGroupID
WHERE invTypes.marketGroupID IS NOT NULL
AND parent3.marketGroupID IS NULL
--AND parent3.marketGroupID IN (350001, 353580, 1041, 477, 2, 475)
ORDER BY invTypes.typeID


SELECT * FROM invMarketGroups 
WHERE marketGroupName like '%Infant%'
ORDER BY marketGroupID

SELECT DISTINCT parentGroup3, parentGroup3id FROM
(
SELECT typeID, typeName, invMarketGroups.marketGroupName, 
parent.marketGroupName AS parentGroup, 
parent2.marketGroupName AS parentGroup2, 
parent3.marketGroupName AS parentGroup3, 
parent3.marketGroupID AS parentGroup3id, 
parent.marketGroupID
--, * 
FROM invTypes
LEFT JOIN invMarketGroups ON invTypes.marketGroupID = invMarketGroups.marketGroupID
LEFT OUTER JOIN invMarketGroups parent ON invMarketGroups.parentGroupID = parent.marketGroupID
LEFT OUTER JOIN invMarketGroups parent2 ON parent.parentGroupID = parent2.marketGroupID
LEFT OUTER JOIN invMarketGroups parent3 ON parent2.parentGroupID = parent3.marketGroupID
WHERE invTypes.marketGroupID IS NOT NULL
--AND parent.marketGroupName like '%blue%'
--AND typeName NOT LIKE '%blueprint%'
--ORDER BY invTypes.typeID
) base
