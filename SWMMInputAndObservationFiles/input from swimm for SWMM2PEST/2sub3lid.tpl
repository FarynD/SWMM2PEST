ptf #
[TITLE]
;;Project Title/Notes

[OPTIONS]
;;Option             Value
FLOW_UNITS           CFS
INFILTRATION         HORTON
FLOW_ROUTING         KINWAVE
LINK_OFFSETS         DEPTH
MIN_SLOPE            0
ALLOW_PONDING        NO
SKIP_STEADY_STATE    NO

START_DATE           05/17/2021
START_TIME           00:00:00
REPORT_START_DATE    05/17/2021
REPORT_START_TIME    00:00:00
END_DATE             05/17/2021
END_TIME             06:00:00
SWEEP_START          1/1
SWEEP_END            12/31
DRY_DAYS             0
REPORT_STEP          00:15:00
WET_STEP             00:05:00
DRY_STEP             01:00:00
ROUTING_STEP         0:00:30 
RULE_STEP            00:00:00

INERTIAL_DAMPING     PARTIAL
NORMAL_FLOW_LIMITED  BOTH
FORCE_MAIN_EQUATION  H-W
VARIABLE_STEP        0.75
LENGTHENING_STEP     0
MIN_SURFAREA         0
MAX_TRIALS           0
HEAD_TOLERANCE       0
SYS_FLOW_TOL         5
LAT_FLOW_TOL         5
MINIMUM_STEP         0.5
THREADS              1

[EVAPORATION]
;;Data Source    Parameters
;;-------------- ----------------
CONSTANT         0.0
DRY_ONLY         NO

[SUBCATCHMENTS]
;;Name           Rain Gage        Outlet           Area     %Imperv  Width    %Slope   CurbLen  SnowPack        
;;-------------- ---------------- ---------------- -------- -------- -------- -------- -------- ----------------
1                "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                5        25       500      0.5      0                       
2                "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                5        25       500      0.5      0                       

[SUBAREAS]
;;Subcatchment   N-Imperv   N-Perv     S-Imperv   S-Perv     PctZero    RouteTo    PctRouted 
;;-------------- ---------- ---------- ---------- ---------- ---------- ---------- ----------
1                0.01       0.1        0.05       0.05       25         OUTLET   
2                0.01       0.1        0.05       0.05       25         OUTLET   

[INFILTRATION]
;;Subcatchment   Param1     Param2     Param3     Param4     Param5    
;;-------------- ---------- ---------- ---------- ---------- ----------
1                3.0        0.5        4          7          0        
2                3.0        0.5        4          7          0        

[LID_CONTROLS]
;;Name           Type/Layer Parameters
;;-------------- ---------- ----------
lid1             BC
lid1             SURFACE    0.0        0.0        0.1        1.0        5        
lid1             SOIL       1          0.5        0.2        0.1        0.5        10.0       3.5      
lid1             STORAGE    1          0.75       0.5        0        
lid1             DRAIN      0          0.5        6          6          0          0                   

lid2             BC
lid2             SURFACE    0.0        0.0        0.1        1.0        5        
lid2             SOIL       2          0.5        0.2        0.1        0.5        10.0       3.5      
lid2             STORAGE    2          0.75       0.5        0        
lid2             DRAIN      2          0.5        6          6          0          0                   

lid3             BC
lid3             SURFACE    0.0        0.0        0.1        1.0        5        
lid3             SOIL       3          0.5        0.2        0.1        0.5        10.0       3.5      
lid3             STORAGE    3          0.75       0.5        0        
lid3             DRAIN      3          0.5        6          6          0          0                   

lid4             BC
lid4             SURFACE    0.0        0.0        0.1        1.0        5        
lid4             SOIL       4          0.5        0.2        0.1        0.5        10.0       3.5      
lid4             STORAGE    4          0.75       0.5        0        
lid4             DRAIN      4          0.5        6          6          0          0                   

[LID_USAGE]
;;Subcatchment   LID Process      Number  Area       Width      InitSat    FromImp    ToPerv     RptFile                  DrainTo          FromPerv  
;;-------------- ---------------- ------- ---------- ---------- ---------- ---------- ---------- ------------------------ ---------------- ----------
1                lid1             1       0          0          0          0          0          "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                        "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                0              
2                lid2             1       0          0          0          0          0          "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                        "C:/Users/fdumont/OneDrive - Environmental Protection Agency (EPA)/Profile/Documents/SWMM2PEST/SWMM2PEST/SWMMInputAndObservationFiles/input from swimm for SWMM2PEST/2sub3lid.txt"                0              

[REPORT]
;;Reporting Options
SUBCATCHMENTS ALL
NODES ALL
LINKS ALL

[TAGS]

[MAP]
DIMENSIONS 0.000 0.000 10000.000 10000.000
Units      None

[COORDINATES]
;;Node           X-Coord            Y-Coord           
;;-------------- ------------------ ------------------

[VERTICES]
;;Link           X-Coord            Y-Coord           
;;-------------- ------------------ ------------------

[Polygons]
;;Subcatchment   X-Coord            Y-Coord           
;;-------------- ------------------ ------------------
1                190.217            7789.855          
1                190.217            7789.855          
1                190.217            7789.855          
1                3432.971           4510.870          
1                7382.246           7155.797          
1                3668.478           9094.203          
1                153.986            7789.855          
2                788.043            2373.188          
2                5679.348           1250.000          
2                8034.420           4384.058          
2                1295.290           2735.507          

