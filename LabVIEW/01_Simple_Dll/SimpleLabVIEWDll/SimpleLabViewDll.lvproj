<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="14008000">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="NI.SortType" Type="Int">3</Property>
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="GlobalVariables.vi" Type="VI" URL="../GlobalVariables.vi"/>
		<Item Name="get32bitInteger.vi" Type="VI" URL="../get32bitInteger.vi"/>
		<Item Name="set32bitInteger.vi" Type="VI" URL="../set32bitInteger.vi"/>
		<Item Name="set32bitIntegerArray.vi" Type="VI" URL="../set32bitIntegerArray.vi"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build">
			<Item Name="SimpleLabViewDll" Type="DLL">
				<Property Name="App_copyErrors" Type="Bool">true</Property>
				<Property Name="App_INI_aliasGUID" Type="Str">{E8DD61FA-2CE0-4559-B641-B733B104A8E5}</Property>
				<Property Name="App_INI_GUID" Type="Str">{4BEA5D0B-31C9-4BDB-BAEE-8953E7EA6EB0}</Property>
				<Property Name="App_serverConfig.httpPort" Type="Int">8002</Property>
				<Property Name="Bld_autoIncrement" Type="Bool">true</Property>
				<Property Name="Bld_buildCacheID" Type="Str">{14DF7128-994D-4F3F-A1CF-8CBA665DCA79}</Property>
				<Property Name="Bld_buildSpecName" Type="Str">SimpleLabViewDll</Property>
				<Property Name="Bld_excludeInlineSubVIs" Type="Bool">true</Property>
				<Property Name="Bld_excludeLibraryItems" Type="Bool">true</Property>
				<Property Name="Bld_excludePolymorphicVIs" Type="Bool">true</Property>
				<Property Name="Bld_localDestDir" Type="Path">../builds/NI_AB_PROJECTNAME/SimpleLabViewDll</Property>
				<Property Name="Bld_localDestDirType" Type="Str">relativeToCommon</Property>
				<Property Name="Bld_modifyLibraryFile" Type="Bool">true</Property>
				<Property Name="Bld_previewCacheID" Type="Str">{CFF9AA86-6149-4B17-952B-64031B4D0EBB}</Property>
				<Property Name="Bld_version.build" Type="Int">1</Property>
				<Property Name="Bld_version.major" Type="Int">1</Property>
				<Property Name="Destination[0].destName" Type="Str">SimpleLabViewDll.dll</Property>
				<Property Name="Destination[0].path" Type="Path">../builds/NI_AB_PROJECTNAME/SimpleLabViewDll/SimpleLabViewDll.dll</Property>
				<Property Name="Destination[0].preserveHierarchy" Type="Bool">true</Property>
				<Property Name="Destination[0].type" Type="Str">App</Property>
				<Property Name="Destination[1].destName" Type="Str">Support Directory</Property>
				<Property Name="Destination[1].path" Type="Path">../builds/NI_AB_PROJECTNAME/SimpleLabViewDll/data</Property>
				<Property Name="DestinationCount" Type="Int">2</Property>
				<Property Name="Dll_compatibilityWith2011" Type="Bool">false</Property>
				<Property Name="Dll_delayOSMsg" Type="Bool">true</Property>
				<Property Name="Dll_headerGUID" Type="Str">{D1043218-2496-40F7-9E9E-146A17F222B9}</Property>
				<Property Name="Dll_libGUID" Type="Str">{E1F6E0B0-E7F5-4839-BA90-D263A326486B}</Property>
				<Property Name="Source[0].itemID" Type="Str">{2F675C3A-4F39-4D09-98E1-ED04194C4E94}</Property>
				<Property Name="Source[0].type" Type="Str">Container</Property>
				<Property Name="Source[1].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[1].itemID" Type="Ref">/My Computer/get32bitInteger.vi</Property>
				<Property Name="Source[1].sourceInclusion" Type="Str">TopLevel</Property>
				<Property Name="Source[1].type" Type="Str">ExportedVI</Property>
				<Property Name="Source[2].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[2].itemID" Type="Ref">/My Computer/set32bitInteger.vi</Property>
				<Property Name="Source[2].sourceInclusion" Type="Str">TopLevel</Property>
				<Property Name="Source[2].type" Type="Str">ExportedVI</Property>
				<Property Name="SourceCount" Type="Int">3</Property>
				<Property Name="TgtF_companyName" Type="Str">ALE System Integration</Property>
				<Property Name="TgtF_fileDescription" Type="Str">SimpleLabViewDll</Property>
				<Property Name="TgtF_internalName" Type="Str">SimpleLabViewDll</Property>
				<Property Name="TgtF_legalCopyright" Type="Str">Copyright © 2015 ALE System Integration</Property>
				<Property Name="TgtF_productName" Type="Str">SimpleLabViewDll</Property>
				<Property Name="TgtF_targetfileGUID" Type="Str">{48C3AAF9-6E1B-47A8-9E30-62EA6E321CE8}</Property>
				<Property Name="TgtF_targetfileName" Type="Str">SimpleLabViewDll.dll</Property>
			</Item>
		</Item>
	</Item>
</Project>
